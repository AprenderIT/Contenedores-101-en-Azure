using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnvironmentVariables.Mvc.Web.Data
{
    public class Profile
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Lastname { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreationTime { get; set; }
        public Guid WebsiteId { get; set; }
        [ForeignKey(nameof(WebsiteId))]
        public virtual Website Website { get; set; }
    }
}
