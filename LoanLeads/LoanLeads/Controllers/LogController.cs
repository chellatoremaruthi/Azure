using LoanLeads.Domain.Repository.Interface;
using LoanLeads.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanLeads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _repository;
        public LogController(ILogRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("GetComunicationLogs")]
        public List<CommunicationLogViewModel> GetComunicationLogs()
        {
            return _repository.GetComunicationLogs();
        }
    }
}
