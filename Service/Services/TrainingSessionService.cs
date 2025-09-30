using Data.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services;

public class TrainingSessionService : ITrainingSessionService
{
    private readonly List<TrainingSessionEntity> _trainingSessions = [];

    public List<TrainingSessionEntity> GetTrainingSessions()
    {
        if (!_trainingSessions.Any())
        {
            for (int i = 0; i < 5; i++)
            {
                _trainingSessions.Add(new TrainingSessionEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Test",
                    Description = "Test",
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                    Location = "Test",
                    Spots = 20,
                    Trainer = "Test"
                });
            }
        }

        return _trainingSessions;
    }

    public void DeleteTrainingSession(string sessionId)
    {

        var trainingSessionToDelete = _trainingSessions.FirstOrDefault(x => x.Id == sessionId);
        if (trainingSessionToDelete != null)
        {
            _trainingSessions.Remove(trainingSessionToDelete);
        }
        else
        {
            throw new Exception();
        }
    }
}
