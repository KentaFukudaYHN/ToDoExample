using System;
using System.Collections.Generic;
using ToDoExample.Entities;
using ToDoExample.Enums;
using ToDoExample.Interfaces;

namespace ToDoExample.Services
{
    /// <summary>
    /// ToDoサービス
    /// </summary>
    public class ToDoService : IToDoService
    {
        private IRepository<ToDoItem> _repository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="repository"></param>
        public ToDoService(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// ToDo取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDoItem GetItem(string id)
        {
            var item = _repository.GetById(id);

            if (item == null)
                throw new ArgumentException("IDに一致するToDoがありません");

            return item;
        }

        /// <summary>
        /// ToDoの一覧取得
        /// </summary>
        /// <returns></returns>
        public List<ToDoItem> GetItemList()
        {
            //状態が未完了のToDoを取得
            var items = _repository.GetBySpec(x => x.State == ToDoState.Incomplete);

            if (items == null)
                return new List<ToDoItem>();

            return items;
        }

        /// <summary>
        /// 新規登録
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Regist(string title, string content)
        {
            //登録用のEntityを生成
            var entity = new ToDoItem()
            {
                ID = Guid.NewGuid().ToString(),
                Titile = title,
                Content = content,
                State = ToDoState.Incomplete,
                UpdateDateTime = DateTime.Now,
                RegistDateTime = DateTime.Now
            };

            _repository.Regist(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void Update(string id, string title, string content)
        {
            //更新対象の取得
            var target = _repository.GetById(id);

            //対象を変更
            target.Titile = title;
            target.Content = content;
            target.UpdateDateTime = DateTime.Now;

            _repository.Update(target);
        }

        /// <summary>
        /// ToDo完了
        /// </summary>
        /// <param name="id"></param>
        public void Complete(string id)
        {
            var target = this.GetItem(id);

            if (target == null)
                throw new ArgumentException("IDに一致するToDoがありません");

            target.State = ToDoState.Complete;
            target.UpdateDateTime = DateTime.Now;
            _repository.Update(target);
        }
    }
}
