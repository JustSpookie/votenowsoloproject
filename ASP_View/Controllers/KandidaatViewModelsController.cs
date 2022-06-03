﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_View.Data;
using ASP_View.Models;
using BusinessLogic;
using DataAccessLayer;
using System.Data;

namespace ASP_View.Controllers
{
    public class KandidaatViewModelsController : Controller
    {
        KandidaatContainer kandidaatContainer = new KandidaatContainer(new KandidaatDAL());
        public KandidaatViewModelsController()
        {
            
        }

        // GET: KandidaatViewModels
        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();
            List<Kandidaat> kandidaatList = kandidaatContainer.GetKandidaten((int)HttpContext.Session.GetInt32("UserID"));

            dataTable.Columns.Add("KandidaatID");
            dataTable.Columns.Add("KandidaatNaam");

            foreach(Kandidaat kandidaat in kandidaatList)
            {
                dataTable.Rows.Add(kandidaat.KandidaatID, kandidaat.KandidaatNaam);
            }

            return View(dataTable);
        }

       

        

        // GET: KandidaatViewModels/AddOrEdit/
        /// <summary>
        /// Deze methode geeft een create of update formulier voor een kandidaat weer
        /// </summary>
        /// <param name="id">ID van de kandidaat</param>
        /// <returns>Update/create formulier</returns>
        public IActionResult AddOrEdit(int id)
        {
            KandidaatViewModel kandidaatViewModel = new KandidaatViewModel();
            if(id > 0)
            {
                Kandidaat kandidaat = kandidaatContainer.GetKandidaat(id);
                kandidaatViewModel.KandidaatId = kandidaat.KandidaatID;
                kandidaatViewModel.KandidaatNaam = kandidaat.KandidaatNaam;
            }
            

            return View(kandidaatViewModel);
        }

        // POST: KandidaatViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("KandidaatId,KandidaatNaam")] KandidaatViewModel kandidaatViewModel)
        {
            

            if (ModelState.IsValid)
            {
                if(id > 0)
                {
                    Kandidaat kandidaat = new Kandidaat(kandidaatViewModel.KandidaatNaam, id);
                    kandidaat.UpdateKandidaat(new KandidaatDAL());
                }
                if(id == 0)
                {
                    kandidaatContainer.AddKandidaat(new Kandidaat(kandidaatViewModel.KandidaatNaam, 0, (int)HttpContext.Session.GetInt32("UserID")));
                }
                
                
                return RedirectToAction(nameof(Index));
            }
            return View(kandidaatViewModel);
        }

        // GET: KandidaatViewModels/Delete/5
        public IActionResult Delete(int id)
        {
            kandidaatContainer.DeleteKandidaat(kandidaatContainer.GetKandidaat(id));


            return View();
        }

        // POST: KandidaatViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            kandidaatContainer.DeleteKandidaat(kandidaatContainer.GetKandidaat(id));
            
            return RedirectToAction(nameof(Index));
        }
    }
}
