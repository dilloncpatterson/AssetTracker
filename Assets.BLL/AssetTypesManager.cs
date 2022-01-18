using Assets.Data;
using Assets.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assets.BLL
{
    public static class AssetTypesManager
    {
        public static IList GetAllAsKeyValuePairs()
        {
            AssetsContext db = new AssetsContext();
            var assetTypes = db.AssetTypes.Select(a => new {
                Value = a.Id,
                Text = a.Name
            }).ToList() ;
            return assetTypes;
        }

        public static List<AssetType> GetAll()
        {
            AssetsContext db = new AssetsContext();
            List<AssetType> assetTypes = db.AssetTypes.OrderBy(o => o.Name).ToList();
            return assetTypes;
        }

        ///// <summary>
        ///// filter assets by type
        ///// </summary>
        ///// <param name="id">asset type id</param>
        ///// <returns></returns>
        //public static List<AssetType> GetAssetsByType(int id)
        //{
        //    AssetsContext db = new AssetsContext();
        //    List<AssetType> assetTypes = db.AssetTypes.
        //        Where(a => a.AssetTypeId == id).
        //        Include(a => a.AssetType).ToList();
        //    return assetTypes;
        //}
        public static AssetType Find(int id)
        {
            AssetsContext db = new AssetsContext();
            AssetType assetType = db.AssetTypes.Find(id);
            return assetType;
        }

        public static void Add(AssetType assetType)
        {
            AssetsContext db = new AssetsContext();
            db.AssetTypes.Add(assetType);
            db.SaveChanges();
        }

        public static void Update(AssetType assetType) // new data object
        {
            AssetsContext db = new AssetsContext();
            AssetType originalAssetType = db.AssetTypes.Find(assetType.Id); //old date object
            originalAssetType.Name = assetType.Name;
            db.SaveChanges();
        }

        public static void Delete(AssetType assetType)
        {
            AssetsContext db = new AssetsContext();           
            db.AssetTypes.Remove(assetType);
            db.SaveChanges();
        }
    }
}
