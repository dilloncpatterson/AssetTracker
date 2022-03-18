using Assets.Data;
using Assets.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assets.BLL//Business Logic Layer
{
    public class AssetsManager
    {
        public static List<Asset> GetAll()
        {
            AssetsContext db = new AssetsContext();
            List<Asset> assets = db.Assets.
                Include(a => a.AssetType).ToList();
            return assets;
        }

        /// <summary>
        /// filter assets by type
        /// </summary>
        /// <param name="id">asset type id</param>
        /// <returns></returns>    
        public static List<Asset> GetAssetsByType(int id)
        {
            AssetsContext db = new AssetsContext();
            List<Asset> assets = db.Assets.
                Where(a => a.AssetTypeId == id).
                Include(a => a.AssetType).ToList();
            return assets;
        }
        public static Asset Find(int id)
        {
            AssetsContext db = new AssetsContext();
            Asset asset = db.Assets.Find(id);
            return asset;
        }

        public static void Add(Asset asset)
        {
            AssetsContext db = new AssetsContext();
            db.Assets.Add(asset);
            db.SaveChanges();
        }


        /*public static void Update(Asset asset) // new data object
        {
            AssetsContext db = new AssetsContext();
            Asset originalAsset = db.Assets.Find(asset.Id); //old date object
            originalAsset.Id = asset.Id;
            db.SaveChanges();
        }*/

      /*  public static void Delete(Asset asset)
        {
            AssetsContext db = new AssetsContext();
           db.Assets.Remove(asset);
            db.SaveChanges();
        }*/
    }
}
