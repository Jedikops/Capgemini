using Capgemini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capgemini.ViewModels
{
    public class CustomerDetailsModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


    }
}