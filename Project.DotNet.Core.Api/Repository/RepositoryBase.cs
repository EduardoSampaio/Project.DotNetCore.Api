using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Project.DotNet.Core.Api.Repository
{
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        protected readonly string ConnectionString;

        public RepositoryBase()
        {
        }

        protected RepositoryBase(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("default");
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<TEntity>();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Insert(entity);
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Update(entity);
            }
        }

        public virtual bool Delete(Int32 id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var entity = GetById(id);

                if (entity == null)
                    throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Select(predicate);
            }
        }
    }
}

