namespace ToDoApp.ViewModel
{
    public class MainViewModel
    {
        public ToDoListViewModel ToDoListViewModel { get; set; }

        public MainViewModel()
        {
            ToDoListViewModel = new ToDoListViewModel();
        }
    }
}