using LoanLeads.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Service.Interface
{
    public interface ILogService
    {
        void SaveLogs(CommunicationLog communicationLog);
        int GetMaxLogid();

        List<CommunicationLog> GetComunicationLogs();
    }
}
