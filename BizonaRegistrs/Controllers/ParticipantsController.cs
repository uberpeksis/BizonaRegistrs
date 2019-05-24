using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BizonaRegistrs.Models;
using Logic;

namespace BizonaRegistrs.Controllers
{
    public class ParticipantsController : Controller
    {
        ParticipantsManager manager = new ParticipantsManager();
        ResultsManager resultsManager = new ResultsManager();
        
        // GET: Participants
        public ActionResult Index()
        {
            NewParticipantsModel model = new NewParticipantsModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(NewParticipantsModel model)
        {
            if (ModelState.IsValid)
            {
                AgeGroupManager ageGroupManager = new AgeGroupManager();
                int parBirthYear = model.parBirthDate.Year;
                string parAgeGroup = ageGroupManager.GetParAgeGroup(parBirthYear, model.parGender);

                manager.CreateNewParticipant(model.parName, model.parSurname, model.parNumber, parAgeGroup, model.parRaceTime);

                TempData["Success"] = "Dalībnieks un rezultāts ir reģistrēti!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Results()
        {
            ParticipantsResultsModel model = new ParticipantsResultsModel();
            model.perPlace = 1;
            model.Participants = resultsManager.SelectAllParticipants();

            return View(model);
        }
    }
}