using System;
using System.ComponentModel;
using ToDoExample.Entities;

namespace ToDoExample.ViewModels
{
    /// <summary>
    /// ToDoのViewModel
    /// </summary>
    public class ToDoListItemViewModel
    {
        private ToDoItem _entity;

        /// <summary>
        /// ID
        /// </summary>
        public string ID => _entity.ID;

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title => _entity.Titile;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToDoListItemViewModel(ToDoItem entity)
        {
            _entity = entity;
        }
    }
}
