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

        [HttpGet("/clients/all")]
        public ActionResult All()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Client chosenClient = Client.Find(id);
            return View(chosenClient);
        }

        [HttpGet("/clients/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Client.DeleteSingleClient(id);
            return RedirectToAction("All");
        }

        [HttpPost("/clients/delete")]
        public ActionResult DeleteAll()
        {
            Client.DeleteAll();
            return RedirectToAction("All");
        }

    }
}