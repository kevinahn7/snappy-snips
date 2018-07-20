using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> listofStylists = Stylist.GetAll();
            return View(listofStylists);
        }

        [HttpPost("/stylists")]
        public ActionResult Create(string name, string details, List<int> specialtyIdList)
        {
            Stylist newStylist = new Stylist(name, details);
            newStylist.Save();
            foreach (int specialtyId in specialtyIdList)
            {
                newStylist.AddSpecialty(specialtyId);
            }


            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/add")]
        public ActionResult Add()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist chosenStylist = Stylist.Find(id);
            return View(chosenStylist);
        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist.DeleteSingleStylist(id);
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/delete")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            return View(currentStylist);
        }

        [HttpPost("/stylists/{id}/edit")]
        public ActionResult Update(string name, int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            currentStylist.Name = name;
            currentStylist.Update();
            return RedirectToAction("Details");
        }

    }
}