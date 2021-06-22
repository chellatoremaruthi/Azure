using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Converters
{
    public class LeadInfromationConverter
    {
        public static LeadInformationViewModel ConvertToViewModel(LeadInformation leadInfo,List<ContactDetail> lstContactDetail)
        {
            
                var lstContactDetailViewModel = new List<ContactDetailsViewModel>();
            lstContactDetailViewModel = ContactDetailsConverter.ConvertToViewModel(lstContactDetail);
            if (leadInfo != null)
            {
                return new LeadInformationViewModel()
                {
                    id = leadInfo.id,
                    CommunicationMode = leadInfo.CommunicationMode,
                    CurrentStatus = leadInfo.CurrentStatus,
                    Leadsource = leadInfo.Leadsource,
                    LoanAmountRequires = leadInfo.LoanAmountRequires,
                    ContactDetails = lstContactDetailViewModel
                };
            }
            return null;
        }

        public static LeadInformation ConvertToModel(LeadInformationViewModel leadInfo)
        {
            if(leadInfo != null)
            return new LeadInformation()
            {
                id = leadInfo.id,
                CommunicationMode = leadInfo.CommunicationMode,
                CurrentStatus = leadInfo.CurrentStatus,
                Leadsource = leadInfo.Leadsource,
                LoanAmountRequires = leadInfo.LoanAmountRequires
            };
            return null;
        }
    }
}
