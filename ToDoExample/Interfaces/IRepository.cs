using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoExample.Interfaces
{
    /// <summary>
    /// データ管理インターフェース
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// 全件取得
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="entitiy"></param>
        /// <returns></returns>
        void Regist(T entitiy);
    }
}
