using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EtohumTask.Models
{
    /// <summary>
    /// The Model class defining User.
    /// Contains all fields of User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Declares Primary Key
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// FirstName is required. It will be displayed on View as First Name
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName is required. It will be displayed on View as Last Name
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// EmailAddress is required. Error message if EmailAddress not valid. It will be displayed on View as Email Address
        /// </summary>
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
    
    }
}