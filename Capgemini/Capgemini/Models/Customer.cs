using System;
using Capgemini.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Capgemini.Models
{
    public class Customer : IAuditInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
