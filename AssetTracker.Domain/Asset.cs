using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assets.Domain
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }//key column in table

        [Required]//string required to be made not null
        public string TagNumber { get; set; }
        
        public int AssetTypeId { get; set; }//decimals or int are not null by default

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]//string 
        public string SerialNumber { get; set; }

        //navigational properties (that will define the foreign keys)
        public AssetType AssetType { get; set; }


    }
}
