using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> listOfSpecialties = Specialty.GetAll();
            return View(listOfSpecialties);
        }

        [HttpPost("/specialties")]
        public ActionResult Create(string name, int stylistId)
        {
            Specialty newSpecialty = new Specialty(name);
            newSpecialty.AddStylist(stylistId);

            newSpecialty.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/add")]
        public ActionResult Add()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/specialties/{id}")]
        public ActionResult Details(int id)
        {
            Specialty chosenSpecialty = Specialty.Find(id);
            return View(chosenSpecialty);
        }

        [HttpGet("/specialties/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Specialty.DeleteSingleSpecialty(id);
            return RedirectToAction("Index");
        }
    }
}