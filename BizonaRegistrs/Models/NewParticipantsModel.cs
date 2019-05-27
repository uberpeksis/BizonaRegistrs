using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [Required(ErrorMessage = "Nav ievadīts dzimšanas gads!")]
        [Display(Name = "Dzimšanas gads:")]
        public DateTime parBirthDate { get; set; }

        [Required(ErrorMessage = "Izvēlies dzimumu!")]
        [Display(Name = "Dzimums:")]
        public string parGender { get; set; }

        [Required(ErrorMessage = "Nav ievadīts dalības numurs!")]
        [Display(Name = "Dalības numurs:")]
        public int parNumber { get; set; }


        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "1. posma laiks:")]
        public int parRaceTime1 { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "2. posma laiks:")]
        public int parRaceTime2 { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "3. posma laiks:")]
        public int parRaceTime3 { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "4. posma laiks:")]
        public int parRaceTime4 { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "5. posma laiks:")]
        public int parRaceTime5 { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "6. posma laiks:")]
        public int parRaceTime6 { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "7. posma laiks:")]
        public int parRaceTime7 { get; set; }

        [Required(ErrorMessage = "Nav ievadīts laiks!")]
        [Display(Name = "8. posma laiks:")]
        public int parRaceTime8 { get; set; }
    }
}