using FluentAssertions;
using Newtonsoft.Json;
using PayForUs.Core.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PayForUs.IntegrationTest
{
    public class ClientApiIntegrationTest
    {
        [Fact]
        public async Task Test_Post()
        {
            var json = JsonConvert.SerializeObject(
                new Client()
                {
                    ClientId = Guid.NewGuid(),
                    Name = "Juliano Nunes",
                    Cpf = "11111111111",
                    LimitCredit = 1000.00
                }
            );

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/Client", stringContent);

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
