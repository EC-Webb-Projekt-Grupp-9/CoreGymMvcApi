using Data.Entities;

namespace Service.Interfaces
{
    public interface ITrainingSessionService
    {
        void DeleteTrainingSession(string sessionId);
        List<TrainingSessionEntity> GetTrainingSessions();
    }
}