using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Helpers;
using ToDoApp.Model;

namespace ToDoApp.ViewModel
{
    public class ToDoListViewModel : ObservableObject
    {
        private IEnumerable<ToDoListItem> _toDoListItems;
        public ToDoListViewModel()
        {
            _toDoListItems = new List<ToDoListItem>();

            var startingItems = new List<ToDoListItem>
            {
                new ToDoListItem("pee pee"),
                new ToDoListItem("poo poo"),
                new ToDoListItem("cah cah"),
            };
            UpdateListItems(startingItems);
        }

        public IEnumerable<ToDoListItem> ToDoItems
        {
            get => _toDoListItems;
            set
            {
                if (_toDoListItems.Equals(value))
                    return;

                foreach (var item in _toDoListItems)
                {
                    item.DeleteItem -= ToDoItemOnDeleteItem;
                }
                
                _toDoListItems = value;

                foreach (var item in _toDoListItems)
                {
                    item.DeleteItem += ToDoItemOnDeleteItem;
                }
                
                OnPropertyChanged(nameof(ToDoItems));
            }
        }

        public void UpdateListItems(IEnumerable<ToDoListItem> listItems)
        {
            ToDoItems = listItems;
        }

        private async void ToDoItemOnDeleteItem(object? sender, EventArgs e)
        {
            await OnDeleteItem((ToDoListItem) sender!);
        }

        private Task OnDeleteItem(ToDoListItem listItem)
        {
            var itemToRemove = ToDoItems.Where(i => i.ItemIdentifier == listItem.ItemIdentifier);
            ToDoItems = ToDoItems.Except(itemToRemove);

            return Task.CompletedTask;
        }
    }
}