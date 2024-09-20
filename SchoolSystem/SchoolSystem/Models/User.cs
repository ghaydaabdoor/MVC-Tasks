﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SchoolSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
    }

}