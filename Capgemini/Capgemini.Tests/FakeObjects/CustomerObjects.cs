using Capgemini.Models;
using System;
using System.Collections.Generic;

namespace Capgemini.Tests.FakeObjects
{
    public static class CustomerObjects
    {
        public static List<Customer> CustomersList
        {
            get
            {
                return new List<Customer>()
                {
                    new Customer()
                    {
                        Id = 1,
                        FirstName = "Maciej",
                        SurName = "Woloszun",
                        Address = "Nieznana 18",
                        PhoneNumber = "753235134",
                        Created = new DateTime(1999, 12,24),
                        Modified = new DateTime(2002, 4, 8)

                    },
                    new Customer()
                    {
                        Id = 2,
                        FirstName = "Piotr",
                        SurName = "Mors",
                        Address = "Wielokwiatowa 113",
                        PhoneNumber = "756434632",
                        Created = new DateTime(1962, 2,2),
                        Modified = new DateTime(1992, 9, 21)

                    },
                    new Customer()
                    {
                        Id = 3,
                        FirstName = "Hieronim",
                        SurName = "Dragon",
                        Address = "Stawowa 13",
                        PhoneNumber = "755426742",
                        Created = new DateTime(1973, 12,13),
                        Modified = new DateTime(2012, 6, 1)

                    }
                };
            }
        }
    }
}
