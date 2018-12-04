﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermissionParts;
using TestWebApp.AddedCode;

namespace TestWebApp.Controllers
{
    public class DataController : Controller
    {
        private static readonly List<string> MyData = new List<string>{ "Red", "Blue", "Green", "Yellow"};

        [HasPermission(Permissions.DataRead)]
        // GET: Data
        public ActionResult Index()
        {
            return View(MyData);
        }

        [HasPermission(Permissions.DataCreate)]
        // GET: Data/Create
        public ActionResult Create()
        {
            return View();
        }

        [HasPermission(Permissions.DataCreate)]
        // POST: Data/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                MyData.Add(collection["Data"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HasPermission(Permissions.DataDelete)]
        // GET: Data/Delete/5
        public ActionResult Delete(int id)
        {
            MyData.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}