using System;
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
        public string Title { get; set; }

        /// <summary>
        /// コンテンツ
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToDoRegistViewModel()
        {
        }
    }
}
