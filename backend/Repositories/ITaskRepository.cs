using TaskTrackrAPI.Models;
using System.Collections.Generic;

namespace TaskTrackrAPI.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? Get(int id);
        TaskItem Create(TaskItem task);
        void Update(TaskItem task);
        void Delete(int id);
    }
}
