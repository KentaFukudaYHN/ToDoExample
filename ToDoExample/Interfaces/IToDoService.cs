﻿using System.Collections.Generic;
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
        /// ToDo取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ToDoItem GetItem(string id);

        /// <summary>
        /// ToDoの一覧取得
        /// </summary>
        List<ToDoItem> GetItemList();

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        void Regist(string title, string content);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        void Update(string id, string title, string content);

        /// <summary>
        /// ToDo完了
        /// </summary>
        /// <param name="id"></param>
        void Complete(string id);
    }
}
