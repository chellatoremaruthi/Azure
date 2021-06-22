using LoanLeads.Domain.Service.Interface;
using LoanLeads.Infrastructure;
using LoanLeads.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LoanLeads.Domain.Service.Implementation
{
    public class LogService : ILogService
    {
        private readonly LoanLeadsDbContext _context;
        public LogService(LoanLeadsDbContext context)
        {
            _context = context;
        }
        public void SaveLogs(CommunicationLog communicationLog)
        {
            _context.CommunicationLogs.Add(communicationLog);
            _context.SaveChanges();
        }
        public int GetMaxLogid()
        {
            return _context.CommunicationLogs.Max(s => s.id);
        }

        public List<CommunicationLog> GetComunicationLogs()
        {
            return _context.CommunicationLogs.ToList();
        }

    }
}
