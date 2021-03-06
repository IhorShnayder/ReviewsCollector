﻿using ReviewsCollector.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ReviewsCollector.Tests
{
    public class CustomDbSetForBaseEntitiy<T> : DbSet<T>, IQueryable, IEnumerable<T> where T : BaseEntity
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public CustomDbSetForBaseEntitiy()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public CustomDbSetForBaseEntitiy(IEnumerable<T> items) : this()
        {
            foreach (var item in items)
            {
                _data.Add(item);
            }
        }

        public override T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public override T Find(params object[] keyValues)
        {
            return this.SingleOrDefault(entity => entity.Id == (int)keyValues.Single());
        }

        public override T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public override T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public override T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_data); }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}
