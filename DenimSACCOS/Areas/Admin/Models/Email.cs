﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DenimSACCOS.Areas.Admin.Models
{
    public class Email
    {
        public int Id { get; set; }
        
        public string From { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string To { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Body { get; set; }
    }
    public class Mail
    {
        [Required(ErrorMessage = "Enter Your Email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number.")]
        [MaxLength(15, ErrorMessage = "Enter Valid Mobile Number.")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string Mobile { get; set; }

        public string To { get; set; }
        public string Subject { get; set; }

        [Required(ErrorMessage = "Enter Message.")]
        public string Body { get; set; }
    }
}