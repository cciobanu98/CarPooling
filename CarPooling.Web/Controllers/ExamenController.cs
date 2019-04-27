using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPooling.Context;
using CarPooling.Domain;
using Microsoft.AspNetCore.Identity;
using CarPooling.Web.ViewModels.Settings;
using CarPooling.DataAcces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarPooling.Web.Models;

namespace CarPooling.Web.Controllers
{
    [Route("Examen")]
    public class ExamenController : Controller
    {
        [HttpGet]
        public IActionResult ExamenForm()
        {
            return View("~/Views/Home/ExamenPage.cshtml");
        }
        [HttpPost]
        public IActionResult ExamenForm(ExamenModel m)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/ExamenPage.cshtml", m);
            }
            return Json(m);
            //return (Json(m));
        }
    }
}
