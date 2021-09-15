
using System;
using System.ComponentModel.DataAnnotations;

namespace C101A.Sql.Api.Data
{
    public class Website
    {
        public Guid Id { get; set; }
        public string ImageLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
