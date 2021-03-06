﻿using System.ComponentModel.DataAnnotations;

namespace DE.IDP.Models.AccountViewModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "emailRequired")]
        public string Email { get; set; }
        [Required(ErrorMessage = "passwordRequired")]
        public string password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
