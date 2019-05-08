using FluentAssertions;
using Newtonsoft.Json;
using PayForUs.Core.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PayForUs.IntegrationTest
{
    public class CardApiIntegrationTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Card");

                response.EnsureSuccessStatusCode();

                //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        
    }
}
