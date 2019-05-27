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

                manager.CreateNewParticipant(
                    model.parName, 
                    model.parSurname, 
                    model.parNumber, 
                    parAgeGroup, 
                    model.parRaceTime1,
                    model.parRaceTime2,
                    model.parRaceTime3,
                    model.parRaceTime4,
                    model.parRaceTime5,
                    model.parRaceTime6,
                    model.parRaceTime7,
                    model.parRaceTime8);

                TempData["Success"] = "Dalībnieks un rezultāts ir reģistrēti!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Results()
        {
            ParticipantsResultsModel model = new ParticipantsResultsModel();
            PointsManager pointsManager = new PointsManager();
            pointsManager.UpdateParPoints();

            AgeGroupManager ageGroupManager = new AgeGroupManager();
            model.ageGroupList = ageGroupManager.GetAgeGroupList();

            model.choice = "Sum";
            model.Participants = resultsManager.SelectAllParticipants();

            return View(model);
        }

        [HttpPost]
        public ActionResult Results(ParticipantsResultsModel model)
        {
            if (model.choice == "1" ||
                model.choice == "2" ||
                model.choice == "3" ||
                model.choice == "4" ||
                model.choice == "5" ||
                model.choice == "6" ||
                model.choice == "7" ||
                model.choice == "8") { RedirectToAction("Results"); }

            AgeGroupManager ageGroupManager = new AgeGroupManager();
            model.ageGroupList = ageGroupManager.GetAgeGroupList();

            model.Participants = resultsManager.SelectAllParticipants();
            model.Participants1 = resultsManager.SelectAllParticipantsForStage1();
            model.Participants2 = resultsManager.SelectAllParticipantsForStage2();
            model.Participants3 = resultsManager.SelectAllParticipantsForStage3();
            model.Participants4 = resultsManager.SelectAllParticipantsForStage4();
            model.Participants5 = resultsManager.SelectAllParticipantsForStage5();
            model.Participants6 = resultsManager.SelectAllParticipantsForStage6();
            model.Participants7 = resultsManager.SelectAllParticipantsForStage7();
            model.Participants8 = resultsManager.SelectAllParticipantsForStage8();

            return View(model);
        }
    }
}