using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace Globomantics.Services
{
    public class ConferenceMemoryService : IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryService()
        {
            conferences.Add(new ConferenceModel
            {
                Id = 1,
                AttendeesTotal = 10,
                Location = "pluralsight.com",
                Name = "PluralSight Conference"
            });
            conferences.Add(new ConferenceModel
            {
                Id = 2,
                AttendeesTotal = 21,
                Location = "pluralsight.com",
                Name = "PluralSight 2 Conference"
            });
        }

        public Task Add(ConferenceModel conference)
        {
            conference.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(conference);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.FirstOrDefault(c => c.Id == id));
        }

        public Task<StatisticsModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticsModel
                {
                    NumberOfAttendees = conferences.Sum(c => c.AttendeesTotal),
                    AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeesTotal)
                };
            });
        }
    }
}
