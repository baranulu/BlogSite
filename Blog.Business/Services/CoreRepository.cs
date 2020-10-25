using Blog.Business.Data;
using Blog.Business.Repositories;
using Blog.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Business.Services
{
    public class CoreRepository<T> : ICoreRepository<T>
        where T : CoreEntity
    {
        #region Constructor
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;
        public CoreRepository(ApplicationContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        #endregion

        #region Add
        public virtual void Add(T entity)
        {
            #region Örnek
            /*
                        switch (entity)
                       {
                           case T t when t is Category c:
                               {
                                   _context.Categories.Add(c);
                                   break;
                               }
                           case T t when t is Post p:
                               {
                                   _context.Posts.Add(p);
                                   break;
                               }
                           case T t when t is PostImage pi:
                               {
                                   _context.PostImages.Add(pi);
                                   break;
                               }
                           default:
                               break;
                       } 
             */
            #endregion

            //_context.Set<T>().Add(entity);

            this._dbSet.Add(entity);
        }
        #endregion

        #region Any
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return this._dbSet.Any(expression);
        }
        #endregion
         
        #region Delete
        public virtual void Delete(Guid id)
        {
            T item = this._dbSet.FirstOrDefault(model => model.Id == id);
            this._dbSet.Remove(item);
        } 
        #endregion

        #region Delete
        public virtual void Delete(T item)
        {
            this._dbSet.Remove(item);
        } 
        #endregion

        #region Delete
        public virtual void Delete(Expression<Func<T, bool>> expression)
        {
            this._dbSet.RemoveRange(GetDefault(expression));
        } 
        #endregion

        #region GetAll
        public virtual IEnumerable<T> GetAll()
        {
            return this._dbSet;
        } 
        #endregion

        #region GetById
        public virtual T GetById(Guid id)
        {
            return this._dbSet.FirstOrDefault(model => model.Id == id);
        } 
        #endregion

        #region GetDefault
        public virtual IEnumerable<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return this._dbSet.Where(expression);
        } 
        #endregion

        #region RollBack
        public virtual void RollBack()
        {
            _context.Dispose();
        } 
        #endregion

        #region Save
        public virtual int Save()
        {
            return this._context.SaveChanges();
        } 
        #endregion

        #region Update
        public virtual void Update(T entity)
        {
            this._dbSet.Update(entity);
        } 
        #endregion
    } 
}
