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
        public ActionResult Index(string name, string details)
        {
            Stylist newStylist = new Stylist(name, details);
            newStylist.Save();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/add")]
        public ActionResult Add()
        {
            return View();
        }
    }
}