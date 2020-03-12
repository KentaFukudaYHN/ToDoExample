using System.Collections.Generic;
using ToDoExample.Interfaces;
using System.Linq;
using ToDoExample.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace ToDoExample.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ToDoContext _db;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EfRepository(ToDoContext db)
        {
            _db = db;
        }

        /// <summary>
        /// IDで取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(string id)
        {
            return _db.Set<T>().Where(x => x.ID == id).FirstOrDefault();
        }

        /// <summary>
        /// 全件取得
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
           return _db.Set<T>().ToList();
        }

        /// <summary>
        /// 条件で取得
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<T> GetBySpec(Expression<Func<T, bool>> criteria)
        {
            return _db.Set<T>().Where(criteria).ToList();
        }

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="entitiy"></param>
        /// <returns></returns>
        public void Regist(T entitiy)
        {
            _db.Add(entitiy);
            _db.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
