﻿using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class Feature:BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string IconName { get; set; }
    }
}
