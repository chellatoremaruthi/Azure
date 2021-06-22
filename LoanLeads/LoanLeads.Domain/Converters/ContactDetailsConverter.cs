using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanLeads.Domain.Converters
{
    public class ContactDetailsConverter
    {
        public static List<ContactDetailsViewModel> ConvertToViewModel(List<ContactDetail> lstContactDetails)
        {
            var lstContactDetailViewModel = new List<ContactDetailsViewModel>();

            foreach (var item in lstContactDetails)
            {
                lstContactDetailViewModel.Add(
                    new ContactDetailsViewModel
                    {
                        ContactName = item.ContactName,
                        ContactNumbers = item.ContactNumbers,
                        ContactType = item.ContactType,
                        DateOfBirth = item.DateOfBirth,
                        EmailAddress = item.EmailAddress,
                        Gender = item.Gender,
                        id = item.id
                    }
                    );
            }
            return lstContactDetailViewModel;
        }

        public static List<ContactDetail> ConvertToModel(List<ContactDetailsViewModel> lstContactDetailsViewModel,int leadInformationId)
        {
            var lstContactDetail = new List<ContactDetail>();

            foreach (var item in lstContactDetailsViewModel)
            {
                lstContactDetail.Add(
                    new ContactDetail
                    {
                        ContactName = item.ContactName,
                        ContactNumbers = item.ContactNumbers,
                        ContactType = item.ContactType,
                        DateOfBirth = item.DateOfBirth,
                        EmailAddress = item.EmailAddress,
                        Gender = item.Gender,
                        id = item.id,
                        LeadInfromationId = leadInformationId
                    }
                    );
            }
            return lstContactDetail;
        }
    }
}
