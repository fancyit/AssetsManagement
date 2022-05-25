using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetsManagement.DL.Models
{
    public class Employee: AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }        
        public string PersonalCode { get; set; }
        public string UserAccount { get; set; }
        public string EMail { get; set; }
        public string JobTitle { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public Guid? ManagerId { get; set; }
        public Employee Manager { get; set; }
        //[JsonIgnore]
        public List<Asset> Assets { get; set; }
    }
}
