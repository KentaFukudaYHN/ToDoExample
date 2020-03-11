using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoExample.Entities
{
    /// <summary>
    /// ToDo情報
    /// </summary>
    public class ToDoItem : BaseEntity
    {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Titile { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime UpdateDateTime { get; set; }

        /// <summary>
        /// 登録日時
        /// </summary>
        public DateTime RegistDateTime { get; set; }
    }
}
