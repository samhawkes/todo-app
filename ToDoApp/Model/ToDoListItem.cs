using System;
using System.Windows.Input;
using ToDoApp.Helpers;

namespace ToDoApp.Model
{
    public class ToDoListItem
    {
        public string ListItemText { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
        public Guid ItemIdentifier { get; }
        
        public ICommand DeleteItemCommand { get; }
        
        public event EventHandler? DeleteItem ;
        
        public ToDoListItem(string listItemText)
        {
            ListItemText = listItemText;
            IsActive = true;
            IsSelected = false;
            ItemIdentifier = Guid.NewGuid();

            DeleteItemCommand = new SimpleCommand(_ => RaiseDeleteItem());
        }

        private void RaiseDeleteItem()
        {
            DeleteItem?.Invoke(this, EventArgs.Empty);
        }
    }
}