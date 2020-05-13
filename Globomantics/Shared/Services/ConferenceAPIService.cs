using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Extensions;
using Shared.Models;

namespace Shared.Services
{
    public class ConferenceAPIService : IConferenceService
    {
        private readonly HttpClient client;

        public ConferenceAPIService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:5003");
            this.client = client;
        }

        public async Task Add(ConferenceModel conference)
        {
            await client.PostAsJsonAsync("/v1/Proposal", conference);
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            var response = await client.GetAsync("/v1/Conference");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<List<ConferenceModel>>();
            
            throw new HttpRequestException(response.ReasonPhrase);
        }

        public async Task<ConferenceModel> GetById(int id)
        {
            var response = await client.GetAsync("/v1/Conference/" + id);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<ConferenceModel>();

            throw new HttpRequestException(response.ReasonPhrase);
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            var response = await client.GetAsync("/v1/Conference/statistics");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<StatisticsModel>();

            throw new HttpRequestException(response.ReasonPhrase);
        }
    }
}
