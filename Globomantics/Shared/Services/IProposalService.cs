using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Services
{
    public interface IProposalService
    {
        Task Add(ProposalModel proposal);
        Task<ProposalModel> Approve(int id);
        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
    }
}
