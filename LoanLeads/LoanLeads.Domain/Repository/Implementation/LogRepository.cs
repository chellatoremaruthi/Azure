using LoanLeads.Domain.Converters;
using LoanLeads.Domain.Repository.Interface;
using LoanLeads.Domain.Service.Interface;
using LoanLeads.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Repository.Implementation
{
    public class LogRepository : ILogRepository
    {
        private readonly ILogService _logService;
        public LogRepository(ILogService logService)
        {
            _logService = logService;
        }
        public void SaveLogs(CommunicationLogViewModel communicationLogViewModel)
        {
            int maxId = _logService.GetMaxLogid();
            communicationLogViewModel.id = maxId + 1;
            _logService.SaveLogs(CommunicationLogConverter.ConvertToModel(communicationLogViewModel));
        }
        public List<CommunicationLogViewModel> GetComunicationLogs()
        {
            var lstLeadInfoVieModel = new List<CommunicationLogViewModel>();
            var leadInfos = _logService.GetComunicationLogs();
            foreach (var item in leadInfos)
            {
                lstLeadInfoVieModel.Add(CommunicationLogConverter.ConvertToViewModel(item));
            }

            return lstLeadInfoVieModel;
        }

    }
}
