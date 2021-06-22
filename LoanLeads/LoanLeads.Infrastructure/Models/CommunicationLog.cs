using LoanLeads.Infrastructure.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanLeads.Infrastructure.Models
{
    public class CommunicationLog
    {
        public int id { get; set; }

        [ForeignKey("LeadInformation")]
        public int LeadId { get; set; }
        public DateTime CommunicationDate { get; set; }
        public string CommunicationMode { get; set; }
        public Status CommunicationLogStatus { get; set; }

    }
}
