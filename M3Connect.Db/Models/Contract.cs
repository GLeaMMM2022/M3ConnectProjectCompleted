using System;
using System.ComponentModel.DataAnnotations;

namespace M3Connect.Db.Models
{
    public class Contract
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
       
        public string IpAddress { get; set; }
       
        public ServiceType ServiceType { get; set; }
       
        public DateTime ContractDate { get; set; }

        public bool IsActive { get; set; }
    }
}
