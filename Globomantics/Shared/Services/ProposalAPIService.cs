using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Extensions;
using Shared.Models;

namespace Shared.Services
{
    public class ProposalAPIService : IProposalService
    {
        private readonly HttpClient client;

        public ProposalAPIService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:5003");
            this.client = client;
        }

        public async Task Add(ProposalModel proposal)
        {
            await client.PostAsJsonAsync("/v1/Proposal", proposal);
        }

        public async Task<ProposalModel> Approve(int id)
        {
            var response = await client.PutAsync("/v1/Proposal/" + id, null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ProposalModel>();
            }
            throw new ArgumentException("Error to approve proposal " + id);
        }

        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            var response = await client.GetAsync("/v1/Proposal/" + conferenceId);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<ProposalModel>>();
            }
            throw new ArgumentException(response.ReasonPhrase);
        }
    }
}
