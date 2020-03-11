using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoExample.Entities
{
    /// <summary>
    /// Entityの親クラス
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public string ID { get; set; }
    }
}
