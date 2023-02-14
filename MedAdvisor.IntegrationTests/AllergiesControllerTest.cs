﻿

using System.Net;
using System.Text.Json;

namespace MedAdvisor.IntegrationTests
{
    public class AllergiesControllerTest: IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public AllergiesControllerTest(TestingWebAppFactory<Program> factory)
             => _client = factory.CreateClient();


        [Fact]
        public async Task Addallergy_returnsOk()
        {

            // Arrange
            var allergyId = "08db0879-0173-4742-8dee-ca4b5a510ab7";
            var content = new StringContent(
                JsonSerializer.Serialize(allergyId), System.Text.Encoding.UTF8, "application/json");

            _client.DefaultRequestHeaders.Add("Authorization", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjA4ZGFmYTVmLWE4ZmItNGU3Ni04ZTkxLThiZGE4MWQ5M2JkMCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3RyaW5nIHN0cmluZyIsImV4cCI6MTY3ODkyMDY1NH0.bLrfme-jzDKoUtjTqNkK2qVcqH7r8XJs6oNfbm8U0bIqFhWnMZQdyv-HccvXsse5WMnAnZK3INl8bFISu1glMA");

            // act
            var response = await _client.PostAsync("/api/Allergies/add/" + allergyId,content);

            //assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task Addallergy_returnBadRequest()
        {
            // Arrange
            var allergyId = "08db0879-0173-4742-8dee-ca4b5a510ab7";
            var content = new StringContent(
                JsonSerializer.Serialize(allergyId), System.Text.Encoding.UTF8, "application/json");
            // act
            var response = await _client.PostAsync("/api/Allergies/add/" + allergyId, content);

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task DeleteAllergy_ReturnsOk()
        {

            // Arrange
            var allergyId = "08db0879-0173-4742-8dee-ca4b5a510ab7";
            _client.DefaultRequestHeaders.Add("Authorization", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjA4ZGFmYTVmLWE4ZmItNGU3Ni04ZTkxLThiZGE4MWQ5M2JkMCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3RyaW5nIHN0cmluZyIsImV4cCI6MTY3ODkyMDY1NH0.bLrfme-jzDKoUtjTqNkK2qVcqH7r8XJs6oNfbm8U0bIqFhWnMZQdyv-HccvXsse5WMnAnZK3INl8bFISu1glMA");

            // act
            var response = await _client.DeleteAsync("/api/Allergies/" + allergyId);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteAllergy_ReturnsBadRequest()
        {

            // Arrange
            var allergyId = "08db0879-0173-4742-8dee-ca4b5a510ab7";
            // act
            var response = await _client.DeleteAsync("/api/Allergy/" + allergyId);

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
