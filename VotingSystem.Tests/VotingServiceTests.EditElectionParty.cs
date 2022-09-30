using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using SmartVotingSystem.Controllers;
using SmartVotingSystem.Models;

namespace VotingSystem.Tests
{
    public partial class VotingServiceTests
    {
        [Fact]
        public async void EditElectionParty_OkResult01()
        {
            // ARRANGE
            var dbName = nameof(VotingServiceTests.EditElectionParty_OkResult01);
            var logger = Mock.Of<ILogger<VotingService>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            var apiController = new VotingService(dbContext, logger);
            int editId = 2;
            PartiesMaster originalPartiesMaster, changedPartiesMaster;
            changedPartiesMaster = new PartiesMaster
            {
                Id = editId,
                PartyName = "--Changed Category Name"
            };

        }
    }
}
