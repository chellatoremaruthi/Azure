using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Repository.Interface
{
    public interface ILeadInfoRepository
    {
        LeadInformationViewModel PostLeadInfoData(LeadInformationViewModel leadInformation);
        List<LeadInformationViewModel> GetLeadInfos();
        LeadInformationViewModel GetLeadInfosById(int id);

        List<ContactDetailsViewModel> GetContactDetail(int leadInfoId);
    }
}