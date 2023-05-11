﻿using System.ComponentModel.DataAnnotations;

namespace Pet_Safe.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
      
    }
}