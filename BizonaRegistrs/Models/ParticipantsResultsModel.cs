using Logic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizonaRegistrs.Models
{
    public class ParticipantsResultsModel
    {
        public List<ParticipantsData> Participants;

        public List<ParticipantsData> Participants1;

        public List<ParticipantsData> Participants2;

        public List<ParticipantsData> Participants3;

        public List<ParticipantsData> Participants4;

        public List<ParticipantsData> Participants5;

        public List<ParticipantsData> Participants6;

        public List<ParticipantsData> Participants7;

        public List<ParticipantsData> Participants8;

        public ParticipantsData ActiveParticipant;

        public List<string> ageGroupList;

        [Display(Name = "Izvēlies:")]
        public string choice { get; set; }

        public int place { get; set; }
    }
}