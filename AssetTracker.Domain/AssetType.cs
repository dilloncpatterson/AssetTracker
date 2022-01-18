using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assets.Domain
{
    [Table("AssetType")]
    public class AssetType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }//Desktop, Monitor, or Phone

        public ICollection<Asset> Assets { get; set; }
    }
}
