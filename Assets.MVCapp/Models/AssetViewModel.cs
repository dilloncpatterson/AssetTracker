using System.ComponentModel.DataAnnotations;


namespace Assets.MVCapp.Models
{
    public class AssetViewModel
    {      
        public string Manufacturer { get; set; }  
        public string TagNumber { get; set; }
        public string Model { get; set; } 
        public string Description { get; set; }    
        public string SerialNumber { get; set; }

        [Display(Name = "Asset Type")]
        public string AssetType { get; set; }

    }
}
