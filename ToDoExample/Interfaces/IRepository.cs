using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDoExample.Interfaces
{
    /// <summary>
    /// データ管理インターフェース
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// IDで取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(string id);

        /// <summary>
        /// 全件取得
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// 条件を指定して取得
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<T> GetBySpec(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="entitiy"></param>
        /// <returns></returns>
        void Regist(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
