﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizonaRegistrs.Models
{
    public class NewParticipantsModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Nav ievadīts vārds!")]
        [Display(Name = "Vārds:")]
        public string parName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Nav ievadīts uzvārds!")]
        [Display(Name = "Uzvārds:")]
        public string parSurname { get; set; }

        [Required(ErrorMessage = "Nav ievadīts dalības numurs!")]
        [Display(Name = "Dalības numurs:")]
        public int parNumber { get; set; }

        [Required(ErrorMessage = "Nav ievadīts vecums!")]
        [Display(Name = "Vecums:")]
        public int parAge { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "Laiks:")]
        public int parRaceTime { get; set; }
    }
}