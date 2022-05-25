using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetsManagement.DL.Models
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string ProductNumber { get; set; }        
        public string Comment { get; set; }
        public Guid? OwnerId { get; set; }
        public Employee Owner { get; set; }
        public Guid? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public Guid? AssetCategoryId { get; set; }
        public AssetCategory AssetCategory { get; set; }
        public Guid? StockId { get; set; }
        public Stock Stock { get; set; }
        public bool IsRetired { get; set; }

    }
}