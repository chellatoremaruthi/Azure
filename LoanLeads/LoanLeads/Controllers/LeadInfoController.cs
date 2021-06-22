using LoanLeads.Domain.Repository.Interface;
using LoanLeads.Infrastructure;
using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanLeads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadInfoController : ControllerBase
    {
        
        private readonly ILeadInfoRepository _repository;
        public LeadInfoController(ILeadInfoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("GetLeadInfos")]
        public List<LeadInformationViewModel> GetLeadInfos()
        {
            return _repository.GetLeadInfos();
        }
        [HttpGet("GetLeadInfosById/{id}")]
        public LeadInformationViewModel GetLeadInfosById(int id)
        {
            return _repository.GetLeadInfosById(id);
        }
        [HttpGet("GetContactDetails/{id}")]
        public List<ContactDetailsViewModel> GetContactDetails(int leadInfoId)
        {
            return _repository.GetContactDetail(leadInfoId);
        }
        [HttpPost("PostLeadInfo")]
        public LeadInformationViewModel PostLeadInfoData(LeadInformationViewModel leadInformationViewModel)
        {
            if (ModelState.IsValid)
            {
                return _repository.PostLeadInfoData(leadInformationViewModel);
            }
            else
            {
                return null;
            }
        }
    }
}
