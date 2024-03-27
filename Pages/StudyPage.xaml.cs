using System;
using System.Timers;

namespace NeknajStudyManager
{
    public partial class StudyPage : ContentPage
    {

        private DateTime startTime;
        private System.Timers.Timer timer;
        public StudyPage()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000); // 1秒ごとに更新
            timer.Elapsed += OnTimerElapsed;
        }


        public void SetPlaceEntry(object sender, EventArgs e)
        {
            if (PlaceEntrySuggestions.SelectedIndex!=-1) { 
                PlaceEntry.Text = PlaceEntrySuggestions.SelectedItem.ToString();
            }
            PlaceEntrySuggestions.SelectedIndex = -1;
        }
        public async void SetTaskIDEntry(object sender, EventArgs e)
        {
            if (TaskIDEntrySuggestions.SelectedIndex==0)
            {
                TaskIDEntry.Text = "";
                await Navigation.PushModalAsync(new NewTaskPage());
            }
            else if (TaskIDEntrySuggestions.SelectedIndex != -1)
            {
                TaskIDEntry.Text = TaskIDEntrySuggestions.SelectedItem.ToString();
            }
            TaskIDEntrySuggestions.SelectedIndex = -1;
        }


        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            timer.Start();
        }

        [Obsolete]
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;

             // UIスレッドでラベルを更新
            Device.BeginInvokeOnMainThread(() =>
            {
                TimeLabel.Text = $"{elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";
            });
        }
    }

}
