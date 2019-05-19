using System;
using System.Collections.Generic;
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
                manager.CreateNewParticipant(model.parName, model.parSurname, model.parNumber, model.parAge, model.parRaceTime);
                TempData["Success"] = "Dalībnieks un rezultāts ir reģistrēti!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Results()
        {
            ParticipantsResultsModel model = new ParticipantsResultsModel();
            model.Participants = resultsManager.SelectAllParticipants();

            return View(model);
        }
    }
}