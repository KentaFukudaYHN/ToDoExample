using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoExample.Entities;

namespace ToDoExample.Interfaces
{
    /// <summary>
    /// ToDoサービスのインターフェース
    /// </summary>
    public interface IToDoService
    {
        /// <summary>
        /// ToDoの一覧取得
        /// </summary>
        List<ToDoItem> GetToDoItems();

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        void Regist(string title, string content);
    }
}
