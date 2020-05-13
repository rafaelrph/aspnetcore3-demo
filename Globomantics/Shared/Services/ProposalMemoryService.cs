using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Services
{
    public class ProposalMemoryService : IProposalService
    {

        List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalMemoryService()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Carlos Karl",
                Title = "Understanding Asp.Net Core 3"
            });

            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 1,
                Speaker = "Albert Braneman",
                Title = "Unit Tests in Asp.Net Core 3"
            });

            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Carlos Karlt",
                Title = "Understanding Asp.Net Core 4"
            });
        }

        public Task Add(ProposalModel proposal)
        {
            proposal.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(proposal);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => proposals.Where(p => p.ConferenceId == conferenceId).AsEnumerable());
        } 

        public Task<ProposalModel> Approve(int id)
        {
            return Task.Run(() =>
            {
                ProposalModel proposal = proposals.First(p => p.Id == id);
                proposal.Approved = true;
                return proposal;
            });
        } 
    }
}
