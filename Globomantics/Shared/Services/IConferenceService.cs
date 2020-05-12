﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
        Task<StatisticsModel> GetStatistics();
        Task Add(ConferenceModel conference);
    }
}
