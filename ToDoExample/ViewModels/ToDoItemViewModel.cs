using System;
using System.ComponentModel;
using ToDoExample.Entities;

namespace ToDoExample.ViewModels
{
    /// <summary>
    /// ToDoのViewModel
    /// </summary>
    public class ToDoItemViewModel
    {
        private ToDoItem _entity;

        /// <summary>
        /// ID
        /// </summary>
        public string id => _entity.ID;

        /// <summary>
        /// タイトル
        /// </summary>
        [DisplayName("タイトル")]
        public string title => _entity.Titile;

        /// <summary>
        /// 内容
        /// </summary>
        [DisplayName("内容")]
        public string content => _entity.Content;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToDoItemViewModel(ToDoItem entity)
        {
            _entity = entity;
        }
    }
}
