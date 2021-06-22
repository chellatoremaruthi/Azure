using LoanLeads.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Repository.Interface
{
    public interface ILogRepository
    {
        void SaveLogs(CommunicationLogViewModel communicationLogViewModel);
        List<CommunicationLogViewModel> GetComunicationLogs();
    }
}
