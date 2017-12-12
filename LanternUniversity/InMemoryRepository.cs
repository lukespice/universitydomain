using System;
using System.Collections.Generic;
using System.Linq;
using LanternUniversity.Models;

namespace LanternUniversity
{

    public interface IRepository<T>
    {
        void Add(T obj);

        T Get(Guid id);

        IList<T> GetAll();
    }

    public class InMemoryRepository<T> : IRepository<T> where T : IIdentifier
    {
        readonly IList<T> _objectList;

        public InMemoryRepository()
        {
            _objectList = new List<T>();
        }

        public void Add(T obj)
        {
            _objectList.Add(obj);
        }

        public T Get(Guid id)
        {
            return _objectList.FirstOrDefault(o => o.Id == id);
        }

        public IList<T> GetAll()
        {
            return _objectList;
        }
    }
}