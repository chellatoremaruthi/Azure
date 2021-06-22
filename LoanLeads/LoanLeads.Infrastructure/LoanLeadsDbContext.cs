using LoanLeads.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoanLeads.Infrastructure
{
    public class LoanLeadsDbContext : DbContext
    {
        //public LoanLeadsDbContext(DbContextOptions<LoanLeadsDbContext> context) : base(context)
        //{

        //}


        public LoanLeadsDbContext(DbContextOptions<LoanLeadsDbContext> options)
            : base(options)
        {
        }
        public DbSet<LeadInformation> LeadInformations { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<CommunicationLog> CommunicationLogs { get; set; }
    }
}
