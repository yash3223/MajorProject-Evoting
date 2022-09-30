using System;
using Xunit;

namespace VotingService.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // ARRANGE
            int a = 1, b = 3;
            int expectedResult = 4;
            int actualResult;

            // ACT
            actualResult = a + b;

            // ASSERT
            Assert.Equal<int>(expectedResult, actualResult);

        }
    }
}
