using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Equivalency;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartVotingSystem.Controllers;
using SmartVotingSystem.Data;
using SmartVotingSystem.Models;

namespace VotingSystem.Tests
{
    public static class DbContextMocker
    {
        public static ApplicationDBContext GetApplicationDbContext(string dbName)
        {
            // Create a fresh service provider for the InMemory Database instance
            var serviceProvider = new ServiceCollection()
                                  .AddEntityFrameworkInMemoryDatabase()
                                  .BuildServiceProvider();

            // Create a new options instance telling the context
            // to use InMemory database with the new service provider created above
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                           .UseInMemoryDatabase(dbName)
                           .UseInternalServiceProvider(serviceProvider)
                           .Options;

            // Create the instance of the DbContext
            var dbContext = new ApplicationDBContext(options);

          

            return dbContext;

        }

        internal static readonly PartiesMaster[] partiesMasters = { 
            new PartiesMaster
            {
                Id = 1,
                PartyType = "center",
                PartyName = "congress"
              

            },
            new PartiesMaster
            {
                Id=2,
                PartyType = "left",
                PartyName = "aap"


            },
            new PartiesMaster
            {
                Id=3,
                PartyType = "right",
                PartyName = "bjp"


            }


        };

        private static void Seeddata(this ApplicationDBContext context)
        {
            context.PartiesMasters.AddRange(partiesMasters);
            context.SaveChanges();

        }







    }
}
