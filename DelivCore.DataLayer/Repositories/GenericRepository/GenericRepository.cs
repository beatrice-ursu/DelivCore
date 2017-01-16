using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DelivCore.DataLayer.DbContext;

namespace DelivCore.DataLayer.Repositories.GenericRepository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        #region ctor

        protected GenericRepository(DelivCoreDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Private members

        private readonly DelivCoreDbContext _context;
        protected readonly DbSet<TEntity> DbSet;

        #endregion

        #region Public methods

        /// <summary>
        ///     generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        /// <summary>
        ///     Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        /// <summary>
        ///     generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        ///     Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        ///     Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        ///     Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        ///     generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

        /// <summary>
        ///     generic method to get many record on the basis of a condition but query able.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).AsQueryable();
        }

        /// <summary>
        ///     generic get method , fetches data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity Get(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).FirstOrDefault();
        }

        /// <summary>
        ///     generic delete method , deletes data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Func<TEntity, bool> where)
        {
            var objects = DbSet.Where(where).AsQueryable();
            foreach (var obj in objects)
                DbSet.Remove(obj);
        }

        /// <summary>
        ///     generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>
        ///     Inclue multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        /// <summary>
        ///     Generic method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }

        /// <summary>
        ///     Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return DbSet.Single(predicate);
        }

        /// <summary>
        ///     The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        ///     Persist the changes to the DB
        /// </summary>
        /// <returns>the number of items modified</returns>
        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var x = ex.EntityValidationErrors.ToList();
                 throw;
            }
        }

        /// <summary>
        ///     Persist the changes to the DB ASYNC
        /// </summary>
        /// <returns>the number of items modified</returns>
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #endregion
    }
}