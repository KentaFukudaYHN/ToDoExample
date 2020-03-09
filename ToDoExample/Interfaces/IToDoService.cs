using System.Threading.Tasks;

namespace ToDoExample.Interfaces
{
    /// <summary>
    /// ToDoサービスのインターフェース
    /// </summary>
    public interface IToDoService
    {
        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        void Regist(string title, string content);
    }
}
