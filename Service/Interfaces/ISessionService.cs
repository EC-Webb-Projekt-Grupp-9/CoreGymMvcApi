using Data.Entities;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface ISessionService
    {
        SessionEntity CreateSession(AddSessionDto formData);
        List<SessionEntity> GetSessions();
    }
}