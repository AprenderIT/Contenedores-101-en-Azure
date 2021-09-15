using System.ComponentModel.DataAnnotations;

namespace EnvironmentVariables.Mvc.Web.Models
{
    public class CreateProfileModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [Url]
        public string Website { get; set; }
    }
}
