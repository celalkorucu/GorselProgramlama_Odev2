using Microsoft.Maui.Storage;

namespace Gorsel_programalama_odev_iki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Google.Apis.Auth;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using FireSharp;
using FireSharp.Config;
using System.Collections.ObjectModel;



 partial class Todo : ContentPage
{
    private ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

    public Todo()
    {
        InitializeComponent();
        taskListView.ItemsSource = tasks;
   
    }

    public void OnAddTaskClicked(object sender, EventArgs e)
    {
        string taskTitle = taskEntry.Text;
        if (!string.IsNullOrEmpty(taskTitle))
        {
            tasks.Add(new TaskItem { Title = taskTitle });
            taskEntry.Text = string.Empty;
        }
    }

    public async void OnEditClick(object sender, EventArgs e)
    {

        if (sender is ImageButton button && button.CommandParameter is TaskItem task)
        {

            string newTitle = await DisplayPromptAsync("Edit Task", "Enter new task title:", initialValue: task.Title);

            if (newTitle != null)
            {
                task.Title = newTitle;
                tasks.Remove(task);
                tasks.Add(task);
            }
        }
    }
    public void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.CommandParameter is TaskItem task)
        {
            tasks.Remove(task);
        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
    }

}