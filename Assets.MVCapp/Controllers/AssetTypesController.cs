using Assets.BLL;
using Assets.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.MVCapp.Controllers
{
    public class AssetTypesController : Controller
    {
        // GET: AssetTypesController
        public ActionResult Index()
        {
            List<AssetType> assetTypes = AssetTypesManager.GetAll();
            return View(assetTypes);
        }

        //// GET: AssetTypesController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: AssetTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetType assetType)
        {
            try
            {
                AssetTypesManager.Add(assetType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            //get asset type with this id and pass to the view
            AssetType assetType = AssetTypesManager.Find(id);

            return View(assetType);
        }

        // POST: AssetTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssetType assetType)//new data
        {
            try
            {
                AssetTypesManager.Update(assetType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            //get asset type with this id and pass to the view
            AssetType assetType = AssetTypesManager.Find(id);
            return View(assetType);
        }

        // POST: AssetTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AssetType assetType)
        {
            try
            {
                AssetTypesManager.Delete(assetType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
