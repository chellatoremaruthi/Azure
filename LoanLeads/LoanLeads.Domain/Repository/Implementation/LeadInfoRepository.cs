using LoanLeads.Domain.Converters;
using LoanLeads.Domain.Repository.Interface;
using LoanLeads.Domain.Service.Interface;
using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Repository.Implementation
{
    public class LeadInfoRepository : ILeadInfoRepository
    {
        private readonly ILeadInfoService _leadInfoService;
        private readonly ILogRepository _logRepository;
        public LeadInfoRepository(ILeadInfoService leadInfoService,ILogRepository logRepository)
        {
            _leadInfoService = leadInfoService;
            _logRepository = logRepository;
        }
        public LeadInformationViewModel PostLeadInfoData(LeadInformationViewModel leadInformation)
        {
            var postedLeadInfo = _leadInfoService.PostLeadInfoData(LeadInfromationConverter.ConvertToModel(leadInformation));
            if(postedLeadInfo.IsUpdate)
            {
                _leadInfoService.DeleteContactDetailsIfChanged(postedLeadInfo.id);
            }
            var postedContactDetails = _leadInfoService.PostContactDetails(ContactDetailsConverter.ConvertToModel(leadInformation.ContactDetails, postedLeadInfo.id));
            _logRepository.SaveLogs(CreateCommunicationLog(postedLeadInfo));
            return LeadInfromationConverter.ConvertToViewModel(postedLeadInfo, postedContactDetails);
        }
        public CommunicationLogViewModel CreateCommunicationLog(LeadInformation leadInformationViewModel)
        {
            return new CommunicationLogViewModel
            {
                CommunicationDate = DateTime.Now,
                CommunicationMode = leadInformationViewModel.CommunicationMode,
                CommunicationLogStatus = leadInformationViewModel.CurrentStatus,
                LeadId = leadInformationViewModel.id
            };
        }
        public List<LeadInformationViewModel> GetLeadInfos()
        {
            var lstLeadInfoVieModel = new List<LeadInformationViewModel>();
            var leadInfos = _leadInfoService.GetLeadInfos();
            foreach (var item in leadInfos)
            {
                var contactDetails = _leadInfoService.GetContactDetail(item.id);
                lstLeadInfoVieModel.Add(LeadInfromationConverter.ConvertToViewModel(item, contactDetails));
            }

            return lstLeadInfoVieModel;
        }
        public LeadInformationViewModel GetLeadInfosById(int id)
        {
            var leadInfo = _leadInfoService.GetLeadInfosById(id);
            
            var contactDetail = _leadInfoService.GetContactDetail(id);
            return LeadInfromationConverter.ConvertToViewModel(leadInfo, contactDetail);
        }

        public List<ContactDetailsViewModel> GetContactDetail(int leadInfoId)
        {
            return ContactDetailsConverter.ConvertToViewModel(_leadInfoService.GetContactDetail(leadInfoId));
        }

    }
}
