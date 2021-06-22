using LoanLeads.Infrastructure.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Infrastructure.ViewModels
{
    public class CommunicationLogViewModel
    {
        public int id { get; set; }
        public int LeadId { get; set; }
        public DateTime CommunicationDate { get; set; }
        public string CommunicationMode { get; set; }
        public Status CommunicationLogStatus { get; set; }
    }
}
