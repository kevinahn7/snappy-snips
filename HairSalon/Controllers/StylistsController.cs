﻿using System;
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

        [HttpGet("/stylists/add")]
        public ActionResult Add()
        {
            return View();
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
    }
}