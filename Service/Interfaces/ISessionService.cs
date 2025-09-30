using Data.Entities;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface ISessionService
    {
        Task<bool> CreateSession(AddSessionDto formData);
        Task<IEnumerable<SessionEntity>> GetSessions();
        Task<bool> DeleteTrainingSession(string sessionId);
    }
}