using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpPost("/clients")]
        public ActionResult Index(string name, int stylistId)
        {
            Client newClient = new Client(name, stylistId);
            newClient.Save();
            return RedirectToAction("Index");
        }
    }
}