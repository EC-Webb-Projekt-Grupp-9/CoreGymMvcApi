using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Dtos;
using Service.Interfaces;

namespace Service.Services
{
    public class SessionService(SqliteDataContext db) : ISessionService
    {
        private readonly SqliteDataContext _db = db;

        public virtual async Task<bool> CreateSession(AddSessionDto formData)
        {
            var newSession = new SessionEntity
            {
                StartTime = DateTime.Now,
                Duration = formData.Duration,
                Title = formData.Title,
                Description = formData.Description,
                Trainer = formData.Trainer,
                Location = formData.Location,
                Spots = formData.Spots
            };

            _db.Sessions.Add(newSession);
            await _db.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IEnumerable<SessionEntity>> GetSessions()
        {
            var sessions = await _db.Sessions.ToListAsync();
            await _db.SaveChangesAsync();
            return sessions;
        }

        public virtual async Task<bool> DeleteTrainingSession(string sessionId)
        {
            
            var trainingSessionToDelete = await _db.Sessions.FirstOrDefaultAsync(x => x.Id == sessionId);
            if (trainingSessionToDelete != null)
            {
                _db.Sessions.Remove(trainingSessionToDelete);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
