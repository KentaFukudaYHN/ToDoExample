using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ToDoExample.Interfaces
{
    /// <summary>
    /// Dbコンテキストのインターフェース
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// データの追加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EntityEntry Add(object entity);

        /// <summary>
        /// 変更を登録
        /// </summary>
        /// <returns></returns>
        public Int32 SaveChanges();
    }
}
