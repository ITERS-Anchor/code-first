﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models
{
    public class userAccount
    {
        [Key]
        [Required(ErrorMessage ="Id is required!")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "FirstName is required!")]
        public string  FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required!")]
        public string  LastName { get; set; }
        [Required(ErrorMessage = "UserName is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}