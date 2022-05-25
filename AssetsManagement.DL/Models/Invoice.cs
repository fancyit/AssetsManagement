using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetsManagement.DL.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Dt { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        [JsonIgnore]
        public List<Asset> Assets { get; set; }
    }
}