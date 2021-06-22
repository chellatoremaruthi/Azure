using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Infrastructure.ViewModels
{
    public class ContactDetailsViewModel
    {
        public int id { get; set; }
        public int ContactType { get; set; }
        public string ContactName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumbers { get; set; }
    }
}
