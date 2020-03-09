using System;
using System.ComponentModel;

namespace ToDoExample.ViewModels
{
    /// <summary>
    /// ToDo登録ViewModel
    /// </summary>
    public class ToDoRegistViewModel
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
        /// コンテンツ
        /// </summary>
        [DisplayName("内容")]
        public string Content { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToDoRegistViewModel()
        {
        }
    }
}
