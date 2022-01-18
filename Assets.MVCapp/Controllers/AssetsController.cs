using Assets.BLL;
using Assets.Domain;
using Assets.MVCapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assets.MVCapp.Controllers
{
    //controller that deals with AssetType
    public class AssetsController : Controller
    {
        public IActionResult Index()
        {
            List<Asset> assets = AssetsManager.GetAll();
            List<AssetViewModel> viewModels = assets.Select(a => new AssetViewModel
            {               
                Manufacturer = a.Manufacturer,
                TagNumber = a.TagNumber,
                Model = a.Model,
                Description = a.Description,
                SerialNumber = a.SerialNumber,
                AssetType = a.AssetType.Name
            }).ToList();
            return View(viewModels);
        }

        /// <summary>
        /// filter assets by type
        /// </summary>
        /// <param name="id">asset type id</param>
        /// <returns></returns>
        public IActionResult Assets(int id)
        {
            List<Asset> filteredAssets = AssetsManager.GetAssetsByType(id);
            return View("Assets", filteredAssets);
            //string result = $"Asset count : {filteredAssets.Count}";
            //return Content(result);
        }

       

        public IActionResult Search()//by asset type
        {
            // call the AssetTypeManager to get all key pairs for asset type drop down list and add to the bag
            var assetTypes = AssetTypesManager.GetAllAsKeyValuePairs();
            //covert to a form that ddl can use, and add to the bag
            var style = new SelectList(assetTypes, "Value", "Text");
            var list = style.ToList();
            list.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "All Types"
            });
            ViewBag.AssetTypeId = list;
           
            return View();//search view with Ajax
        }

        //auxillary method that retrieves filtered assets for Ajax function
        protected IEnumerable GetAssetTypes()
        {
            var assetTypes = AssetTypesManager.GetAllAsKeyValuePairs();
            //covert to a form that ddl can use, and add to the bag
            var list = new SelectList(assetTypes, "Value", "Text");
            return list;
        }

        public IActionResult SearchByAssetType(int id)
        {
            //// call the AssetTypeManager to get all key pairs for asset type drop down list and add to the bag
            //var assetTypes = AssetTypesManager.GetAllAsKeyValuePairs();
            ////covert to a form that ddl can use, and add to the bag
            //var list = new SelectList(assetTypes, "Value", "Text");
            //ViewBag.AssetTypeId = list;
            return ViewComponent("AssetsByType", id);
        }

        public IActionResult Create()
        {
            // call the AssetTypeManager to get all key pairs for asset type drop down list and add to the bag
            var assetTypes = AssetTypesManager.GetAllAsKeyValuePairs();
            //covert to a form that ddl can use, and add to the bag
            var list = new SelectList(assetTypes, "Value", "Text");
            ViewBag.AssetTypeId = list;


            ViewBag.AssetTypeId = GetAssetTypes();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            try
            {
                AssetsManager.Add(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();// the same view
            }
        }

        //public ActionResult Edit(int id)
        //{
        //    //get asset type with this id and pass to the view
        //    Asset asset = AssetsManager.Find(id);
        //    return View();
        //}

        //// POST: AssetTypesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Asset asset)//new data
        //{
        //    try
        //    {
        //        AssetsManager.Update(asset);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(asset);
        //    }
        //}

        //// GET: AssetTypesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    //get asset type with this id and pass to the view
        //    Asset asset = AssetsManager.Find(id);
        //    return View(asset);
        //}

        //// POST: AssetTypesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, Asset asset)
        //{
        //    try
        //    {
        //        AssetsManager.Delete(asset);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
