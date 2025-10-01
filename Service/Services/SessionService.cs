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

        public virtual async Task<SessionEntity?> GetSessionById(string sessionId)
        {
            var session = await _db.Sessions.FirstOrDefaultAsync(x => x.Id == sessionId);
            await _db.SaveChangesAsync();
            return session;
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

        public virtual async Task<bool> EditTrainingSession(EditSessionDto formData)
        {
            var trainingSessionToEdit = await _db.Sessions.FirstOrDefaultAsync(x => x.Id == formData.Id);
            if (trainingSessionToEdit != null)
            {
                trainingSessionToEdit.StartTime = DateTime.Now;
                trainingSessionToEdit.Duration = formData.Duration;
                trainingSessionToEdit.Title = formData.Title;
                trainingSessionToEdit.Description = formData.Description;
                trainingSessionToEdit.Trainer = formData.Trainer;
                trainingSessionToEdit.Location = formData.Location;
                trainingSessionToEdit.Spots = formData.Spots;

                _db.Sessions.Update(trainingSessionToEdit);
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
