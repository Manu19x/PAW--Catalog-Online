﻿using System.ComponentModel.DataAnnotations;

namespace Catalog.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string AccountType { get; set; }
    }
}
