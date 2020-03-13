using System.Collections.Generic;
using ToDoExample.Entities;

namespace ToDoExample.ViewModels
{
    /// <summary>
    /// ToDo
    /// </summary>
    public class ToDoListViewModel
    {
        /// <summary>
        /// ToDoItemの項目
        /// </summary>
        public List<ToDoListItemViewModel> Items { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToDoListViewModel(List<ToDoItem> todoItems)
        {
            Items = todoItems.ConvertAll(x => new ToDoListItemViewModel(x));
        }
    }
}
