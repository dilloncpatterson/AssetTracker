using Assets.BLL;
using Assets.Domain;
using Assets.MVCapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.MVCapp.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets = null;
            if (id == 0)
                assets = AssetsManager.GetAll();
            else
                assets = AssetsManager.GetAssetsByType(id);

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
    }
}
