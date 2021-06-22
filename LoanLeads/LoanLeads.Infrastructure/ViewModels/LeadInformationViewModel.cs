using LoanLeads.Infrastructure.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanLeads.Infrastructure.ViewModels
{
    public class LeadInformationViewModel
    {
        public int id { get; set; }
        public decimal LoanAmountRequires { get; set; }
        public LeadSource Leadsource { get; set; }
        public string CommunicationMode { get; set; }
        public Status CurrentStatus { get; set; }
        [MinLength(1)]
        public List<ContactDetailsViewModel> ContactDetails { get; set; }
    }
}
