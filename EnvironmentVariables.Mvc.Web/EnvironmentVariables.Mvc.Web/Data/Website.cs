using System;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentVariables.Mvc.Web.Data
{
    public class Website
    {
        public Guid Id { get; set; }
        [Display(Name = "Imagen")]
        public string ImageLink { get; set; }
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Website")]
        public string Link { get; set; }
    }
}
