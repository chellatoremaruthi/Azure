using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Converters
{
    public class CommunicationLogConverter
    {
        public static CommunicationLogViewModel ConvertToViewModel(CommunicationLog communicationLog)
        {
            return new CommunicationLogViewModel()
            {
                CommunicationDate = communicationLog.CommunicationDate,
                CommunicationLogStatus = communicationLog.CommunicationLogStatus,
                CommunicationMode = communicationLog.CommunicationMode,
                id = communicationLog.id,
                LeadId = communicationLog.LeadId
            };
        }

        public static CommunicationLog ConvertToModel(CommunicationLogViewModel communicationLog)
        {
            
                return new CommunicationLog()
                {
                    CommunicationDate = communicationLog.CommunicationDate,
                    CommunicationLogStatus = communicationLog.CommunicationLogStatus,
                    CommunicationMode = communicationLog.CommunicationMode,
                    id = communicationLog.id,
                    LeadId = communicationLog.LeadId
                };
        }
    }
}
