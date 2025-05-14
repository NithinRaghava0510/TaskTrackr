using TaskTrackrAPI.Data;
using TaskTrackrAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace TaskTrackrAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _db;

        public TaskRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<TaskItem> GetAll() =>
            _db.Tasks.ToList();

        public TaskItem? Get(int id) =>
            _db.Tasks.Find(id);

        public TaskItem Create(TaskItem task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
            return task;
        }

        public void Update(TaskItem task)
        {
            _db.Tasks.Update(task);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _db.Tasks.Find(id);
            if (entity != null)
            {
                _db.Tasks.Remove(entity);
                _db.SaveChanges();
            }
        }
    }
}
