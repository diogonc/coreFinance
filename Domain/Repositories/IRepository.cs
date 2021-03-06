﻿using System.Collections.Generic;

namespace CoreFinance.Domain.Repositories
{
    public interface IRepository<T> where T : Model
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string propertyUuid);
        T Get(string uuid, string propertyUuid);
        void Update(T model);
        void Create(T model);
        void Delete(string uuid, string propertyUuid);
    }
}
