﻿namespace NeknajStudyManager
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        async void GoToTaskTablePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskTablePage());
        }
        async void GoToProcessTablePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProcessTablePage());
        }
    }

}
