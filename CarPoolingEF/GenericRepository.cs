﻿using System.Collections.Generic;
using CarPooling.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarPooling
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private CarPoolingContext context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            context = new CarPoolingContext();
            table = context.Set<T>();
        }
        public void Delete(object id)
        {
            T elem = table.Find(id);
            table.Remove(elem);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
