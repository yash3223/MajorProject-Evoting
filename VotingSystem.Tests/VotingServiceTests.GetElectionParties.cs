using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SmartVotingSystem.Controllers;
using SmartVotingSystem.Models;
using Xunit;

namespace VotingSystem.Tests
{
    public partial class VotingServiceTests
    {
        [Fact]

        public void GetElectionParties_OkResult()
        {
            //ARRANGE
            var dbName = nameof(VotingServiceTests.GetElectionParties_OkResult);
            var logger = Mock.Of<ILogger<VotingService>>();
            var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new VotingService(dbContext, logger);

            //ACT
            IActionResult actionResult = (IActionResult)controller.GetElectionParties();

            

            //ASSERT
            Assert.IsType<OkObjectResult>(actionResult);

            // --- Check if the HTTP Response Code is 200 "Ok"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            int actualStatusCode = (actionResult as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }


        public void GetElectionParties_CheckCorrectResult()
        {
            // ARRANGE
            var dbName = nameof(VotingServiceTests.GetElectionParties_OkResult);
            var logger = Mock.Of<ILogger<VotingService>>();
            var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var apiController = new VotingService(dbContext, logger);

            // ACT: Call the API action method
            var actionResult = apiController.GetElectionParties().Result;

            // ASSERT: Check if the ActionResult is of the type OkObjectResult
            Assert.IsType<OkObjectResult>(actionResult);


            // ACT: Extract the OkResult result 
            var okResult = actionResult.Should().BeOfType<OkObjectResult>().Subject;

            // ASSERT: if the OkResult contains the object of the Correct Type
            Assert.IsAssignableFrom<List<PartiesMaster>>(okResult.Value);


            // ACT: Extract the Categories from the result of the action
            var partiesFromApi = okResult.Value.Should().BeAssignableTo<List<PartiesMaster>>().Subject;

            // ASSERT: if the categories is NOT NULL
            Assert.NotNull(partiesFromApi);

            // ASSERT: if the number of categories in the DbContext seed data
            //         is the same as the number of categories returned in the API Result
            Assert.Equal<int>(expected: DbContextMocker.partiesMasters.Length,
                              actual: partiesFromApi.Count);

            // ASSERT: Test the data received from the API against the Seed Data
            int ndx = 0;
            foreach (PartiesMaster parties in DbContextMocker.partiesMasters)
            {
                // ASSERT: check if the Category ID is correct
                Assert.Equal<int>(expected: parties.Id,
                                  actual: partiesFromApi[ndx].Id);

                // ASSERT: check if the Category Name is correct
                Assert.Equal(expected: parties.PartyName,
                             actual: partiesFromApi[ndx].PartyName);

                _testOutputHelper.WriteLine($"Compared Row # {ndx} successfully");

                ndx++;          // now compare against the next element in the array
            }
        }
    }

 }


