using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using LoanLeads.Infrastructure;
using System.Linq;
using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.Models.Enum;
using System;
using LoanLeads.Domain.Repository.Implementation;
using LoanLeads.Domain.Service.Implementation;
using LoanLeads.Controllers;
using LoanLeads.Infrastructure.ViewModels;
using System.Collections.Generic;

namespace LoanLeads.Tests
{
    public class Tests
    {
        private DbContextOptions<LoanLeadsDbContext> dbContextOptions = new DbContextOptionsBuilder<LoanLeadsDbContext>()
        .UseInMemoryDatabase(databaseName: "LoanLeadsDbTest")
        .Options;
        private LeadInfoController controller;
        [SetUp]
        public void Setup()
        {
            var context = new LoanLeadsDbContext(dbContextOptions);
           

        }

        [Test]
        public void TestDatabaseSetup()
        {
            var getLeadInfos = controller.GetLeadInfos();
            Assert.IsTrue(getLeadInfos.Count > 0);
        }
        [Test]
        public void PostLeadInfo()
        {

            var leadInformationViewModel = new LeadInformationViewModel
            {
                id = 3,
                LoanAmountRequires = 300000,
                Leadsource = 0,
                CommunicationMode = "",
                CurrentStatus = 0,
                ContactDetails = new List<ContactDetailsViewModel>() {
                   new ContactDetailsViewModel{
                               id = 0,
                               ContactType = 0,
                               ContactName = "Ravan",
                               DateOfBirth = DateTime.Now.AddYears(-100),
                               Gender = "Male",
                               EmailAddress = "ravan@gmail.com",
                               ContactNumbers = "800000002"
                           }
               }
            };

            var leadInfosBeforePost = controller.GetLeadInfos();
            controller.PostLeadInfoData(leadInformationViewModel);
            var leadInfosAfterPost = controller.GetLeadInfos();

            Assert.IsTrue(leadInfosBeforePost.Count+1 == leadInfosAfterPost.Count);
        }
    }
}
