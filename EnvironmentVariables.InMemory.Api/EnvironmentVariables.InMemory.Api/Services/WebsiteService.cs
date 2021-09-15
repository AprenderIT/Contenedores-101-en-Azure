using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

using EnvironmentVariables.InMemory.Api.Data;

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnvironmentVariables.InMemory.Api.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly HttpClient _httpClient;
        private readonly MyContext _context;
        const int BytesToRead = 1024 * 1024;

        public WebsiteService(HttpClient httpClient, MyContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<Website> CreateAsync(Uri websiteUri)
        {
            Website website = new();
            try
            {
                var response = await _httpClient.GetAsync(websiteUri, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                var html = await response.Content.ReadAsStringAsync();

                website = await CompleteTagsAsync(websiteUri, html);
            }
            catch (Exception)
            {
            }
            finally
            {
                website.Link = websiteUri.ToString();
                await _context.Websites.AddAsync(website);
                await _context.SaveChangesAsync();
            }

            return website;
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.Websites.RemoveRange(_context.Websites.Where(x => x.Id == id));
            await _context.SaveChangesAsync();
        }

        private async Task<Website> CompleteTagsAsync(Uri websiteUri, string html)
        {
            var config = Configuration.Default;
            using var context = BrowsingContext.New(config);
            using var doc = await context.OpenAsync(req => req.Content(html));

            var elements = doc.DocumentElement.Descendents()
                .Where(x => x.NodeType == NodeType.Element);

            var metatags = elements.OfType<IHtmlMetaElement>();


            var image = metatags.Where(x =>
                x.Attributes["property"]?.Value == "og:image" ||
                x.Attributes["property"]?.Value == "twitter:image")
                .Select(x => x.Attributes["content"]?.Value)
                .FirstOrDefault();


            var description = metatags.Where(x =>
            x.Attributes["property"]?.Value == "og:description" ||
            x.Attributes["name"]?.Value == "description" ||
            x.Attributes["property"]?.Value == "twitter:description")
                .Select(x => x.Attributes["content"]?.Value)
                .FirstOrDefault();

            var title = metatags.Where(x =>
            x.Attributes["property"]?.Value == "og:title" ||
            x.Attributes["name"]?.Value == "title" ||
            x.Attributes["property"]?.Value == "twitter:title")
                 .Select(x => x.Attributes["content"]?.Value)
                 .FirstOrDefault();


            if (string.IsNullOrWhiteSpace(title))
            {
                title = elements.OfType<IHtmlTitleElement>().FirstOrDefault()?.InnerHtml;
            }


            Website website = new()
            {
                Title = title,
                Description = description
            };


            if (!string.IsNullOrWhiteSpace(image))
            {
                if (Uri.IsWellFormedUriString(image, UriKind.Relative))
                {
                    var imageUrl = new Uri(websiteUri, image);
                    website.ImageLink = imageUrl.ToString();
                }
                else
                {
                    website.ImageLink = image;
                }
            }

            return website;
        }
    }
}
