using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories.Sql
{
    public abstract class Repository<T> : IRepository<T> where T : Model
    {
        private IList<T> Entities { get; set; }

        public IEnumerable<T> GetAll()
        {
            return Entities;
        }

        public IEnumerable<T> GetAll(string propertyUuid)
        {
            return Entities.Where(entity => entity.PropertyUuid == propertyUuid);
        }

        public T Get(string uuid, string propertyUuid)
        {
            return Entities.FirstOrDefault();
        }

        public void Create(T model)
        {
        }

        public void Update(T model)
        {

        }

        public void Delete(string uuid, string propertyUuid)
        {

        }
    }
}
