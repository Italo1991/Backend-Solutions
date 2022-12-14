using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Italo.Customer.Tests
{
    public class Test
    {
        public Test()
        {

        }

        [Fact]
        public void Validate()
        {
            var number = 2;
            number.Should().Be(3);
        }
    }
}
