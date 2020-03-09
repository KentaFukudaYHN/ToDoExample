using System;
using System.Threading.Tasks;

namespace ToDoExample.Interfaces
{
    /// <summary>
    /// データ管理インターフェース
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="entitiy"></param>
        /// <returns></returns>
        void Regist(T entitiy);
    }
}
