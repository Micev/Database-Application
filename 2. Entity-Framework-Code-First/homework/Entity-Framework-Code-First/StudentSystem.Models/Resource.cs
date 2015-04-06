namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Resource
    {
        ﻿
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }


        [MaxLength(100)]
        public string Link { get; set; }

    }
}
