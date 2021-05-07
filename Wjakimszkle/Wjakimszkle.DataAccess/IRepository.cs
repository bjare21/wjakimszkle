﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess
{
    public interface IRepository<T> where T:EntityBase
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
