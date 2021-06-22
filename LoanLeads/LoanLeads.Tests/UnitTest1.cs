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
            controller = new LeadInfoController(new LeadInfoRepository(new LeadInfoService(context)));
            if (context.LeadInformations.Any())
            {
                return;  
            }

            var leadInfoRama = new LeadInformation
            {
                id = 1,
                LoanAmountRequires = 100000,
                CommunicationMode = "",
                CurrentStatus = Status.InitialCommunication,
                Leadsource = LeadSource.Emailer
            };
            context.LeadInformations.Add(
                leadInfoRama
                );
            context.ContactDetails.Add(
               new ContactDetail
               {
                   ContactName = "Raja",
                   ContactNumbers = "8000000000",
                   ContactType = 1,
                   DateOfBirth = new DateTime(1991, 7, 5),
                   EmailAddress = "raja@gmail.com",
                   Gender = "Male",
                   id = 1,
                   LeadInfromationId = leadInfoRama.id
               }
            );
            var leadInfoSita = new LeadInformation
            {
                id = 2,
                LoanAmountRequires = 200000,
                CommunicationMode = "",
                CurrentStatus = Status.InitialCommunication,
                Leadsource = LeadSource.Emailer
            };
            context.LeadInformations.Add(
                leadInfoSita
                );
            context.ContactDetails.Add(
               new ContactDetail
               {
                   ContactName = "Rani",
                   ContactNumbers = "8000000001",
                   ContactType = 1,
                   DateOfBirth = new DateTime(1995, 7, 5),
                   EmailAddress = "Rani@gmail.com",
                   Gender = "Female",
                   id = 2,
                   LeadInfromationId = leadInfoSita.id
               }
            );
            context.CommunicationLogs.AddRange(
                new CommunicationLog
                {
                    id = 1,
                    LeadId = 1,
                    CommunicationDate = DateTime.Now.AddDays(-10),
                    CommunicationMode = "",
                    CommunicationLogStatus = Status.InitialCommunication
                },
                new CommunicationLog
                {
                    id = 2,
                    LeadId = 2,
                    CommunicationDate = DateTime.Now,
                    CommunicationMode = "",
                    CommunicationLogStatus = Status.InitialCommunication
                }
                );

            context.SaveChanges();

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