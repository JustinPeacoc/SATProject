using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SATProject.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "*Your name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Your email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "*Message is required")]
        [UIHint("MultilineText")]
        public string Message { get; set; }

    }
}