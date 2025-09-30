using Data.Entities;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Service.Services
{
    public class SessionService : ISessionService
    {
        private readonly List<SessionEntity> sessions;
        public SessionEntity CreateSession(AddSessionDto formData)
        {
            var newSession = new SessionEntity
            {
                Id = Guid.NewGuid(),
                StartTime = DateTime.Now,
                Duration = formData.Duration,
                Title = formData.Title,
                Description = formData.Description,
                Trainer = formData.Trainer,
                Location = formData.Location,
                Spots = formData.Spots
            };

            sessions.Add(newSession);
            return newSession;
        }

        public List<SessionEntity> GetSessions()
        {
            var sessions = new List<SessionEntity>();
            return sessions;
        }
    }
}
