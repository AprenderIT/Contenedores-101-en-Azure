﻿
using System.ComponentModel.DataAnnotations;

namespace C101A.Sql.Api.Models
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
