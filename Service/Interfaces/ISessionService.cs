using Data.Entities;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface ISessionService
    {
        Task<bool> CreateSession(AddSessionDto formData);
        Task<IEnumerable<SessionEntity>> GetSessions();
        Task<bool> EditTrainingSession(EditSessionDto formData);
        Task<bool> DeleteTrainingSession(string sessionId);
        Task<SessionEntity?> GetSessionById(string sessionId);
    }
}