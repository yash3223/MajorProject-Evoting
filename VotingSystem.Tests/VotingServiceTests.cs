using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace VotingSystem.Tests
{
    
    public partial class VotingServiceTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public VotingServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

    }
}
