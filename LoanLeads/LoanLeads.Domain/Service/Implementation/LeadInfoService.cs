using LoanLeads.Domain.Service.Interface;
using LoanLeads.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LoanLeads.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LoanLeads.Domain.Service.Implementation
{
    public class LeadInfoService : ILeadInfoService
    {
        private readonly LoanLeadsDbContext _context;
        public LeadInfoService(LoanLeadsDbContext context)
        {
            _context = context;
        }
        public LeadInformation PostLeadInfoData(LeadInformation leadInformation)
        {
            EntityEntry<LeadInformation> result;
            if (_context.LeadInformations.Any(s => s.id == leadInformation.id))
            {
                result = _context.LeadInformations.Update(leadInformation);
                result.Entity.IsUpdate = true;
            }
            else
            {
                result = _context.LeadInformations.Add(leadInformation);                
            }
            _context.SaveChanges();
            return result.Entity;
        }
        public List<ContactDetail> PostContactDetails(List<ContactDetail> lstContactDetail)
        {
            var reurnVal = new List<ContactDetail>();
            EntityEntry<ContactDetail> result;
           
            foreach (var item in lstContactDetail)
            {
                if (_context.ContactDetails.Any(s => s.id == item.id))
                {
                    result = _context.ContactDetails.Update(item);
                }
                else
                {
                    result = _context.ContactDetails.Add(item);
                }
                    
                reurnVal.Add(result.Entity);
            }
            _context.SaveChanges();
            return reurnVal;
        }

        public void DeleteContactDetailsIfChanged(int leadInfoId)
        {
            _context.ContactDetails.RemoveRange(GetContactDetail(leadInfoId));
            _context.SaveChanges();
        }

        public List<LeadInformation> GetLeadInfos()
        {
            return _context.LeadInformations.ToList();
        }
        public LeadInformation GetLeadInfosById(int id)
        {
            return _context.LeadInformations.Where(s=>s.id==id).FirstOrDefault();
        }

        public List<ContactDetail> GetContactDetail(int leadInfoId)
        {
            return _context.ContactDetails.Where(s => s.LeadInfromationId == leadInfoId).ToList();
        }


    }
}
