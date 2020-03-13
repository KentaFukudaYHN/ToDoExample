using System;
using System.ComponentModel;
using ToDoExample.Entities;

namespace ToDoExample.ViewModels
{
    public class ToDoDetailViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [DisplayName("タイトル")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [DisplayName("内容")]
        public string Content { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToDoDetailViewModel(ToDoItem entity)
        {
            ID = entity.ID;
            Title = entity.Titile;
            Content = entity.Content;
        }

        /// <summary>
        /// コンストラクタ ※ControllerでBindingする場合、パラメーター無しのコンストラクタが必要
        /// </summary>
        public ToDoDetailViewModel() { }
    }
}
