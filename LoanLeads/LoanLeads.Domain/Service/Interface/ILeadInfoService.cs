using LoanLeads.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Service.Interface
{
    public interface ILeadInfoService
    {
        LeadInformation PostLeadInfoData(LeadInformation leadInformation);
        List<ContactDetail> PostContactDetails(List<ContactDetail> contactDetail);

        List<LeadInformation> GetLeadInfos();

        LeadInformation GetLeadInfosById(int id);

        void DeleteContactDetailsIfChanged(int leadInfoId);
        List<ContactDetail> GetContactDetail(int leadInfoId);

    }
}
