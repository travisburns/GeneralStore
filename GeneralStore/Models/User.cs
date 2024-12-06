using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralStore.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}


