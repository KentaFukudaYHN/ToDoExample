using System;
using ToDoExample.Entities;
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
        /// 登録
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Regist(string title, string content)
        {
            var entity = new ToDoItem()
            {
                ID = Guid.NewGuid().ToString(),
                Titile = title,
                Content = content,
                UpdateDateTime = DateTime.Now,
                RegistDateTime = DateTime.Now
            };

            _repository.Regist(entity);
        }
    }
}
