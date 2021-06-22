using LoanLeads.Infrastructure.Models;
using LoanLeads.Infrastructure.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanLeads.Infrastructure
{
    public class DataGenerator
    {
        private readonly DbContext _context;
        public DataGenerator(DbContext context)
        {
            _context = context;
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LoanLeadsDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<LoanLeadsDbContext>>()))
            {
                // Look for any board games.
                if (context.LeadInformations.Any())
                {
                    return;   // Data was already seeded
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
                       ContactName = "Rama",
                       ContactNumbers = "9000000000",
                       ContactType = 1,
                       DateOfBirth = new DateTime(1991, 7, 5),
                       EmailAddress = "rama@gmail.com",
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
                       ContactName = "Sita",
                       ContactNumbers = "9000000001",
                       ContactType = 1,
                       DateOfBirth = new DateTime(1995, 7, 5),
                       EmailAddress = "sita@gmail.com",
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
        }
    }

}
