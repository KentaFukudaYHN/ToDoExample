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
        public string ID => _entity.ID;

        /// <summary>
        /// タイトル
        /// </summary>
        [DisplayName("タイトル")]
        public string Title => _entity.Titile;

        /// <summary>
        /// 内容
        /// </summary>
        [DisplayName("内容")]
        public string Content => _entity.Content;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToDoItemViewModel(ToDoItem entity)
        {
            _entity = entity;
        }
    }
}
