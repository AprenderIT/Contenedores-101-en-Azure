
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C101A.InMemory.Api.Data
{
    public class Profile
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        public DateTime CreationTime { get; set; }
        public Guid WebsiteId { get; set; }
        [ForeignKey(nameof(WebsiteId))]
        public virtual Website Website { get; set; }
    }
}
