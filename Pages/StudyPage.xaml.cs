
namespace NeknajStudyManager
{
    public partial class StudyPage : ContentPage
    {

        public StudyPage()
        {
            InitializeComponent();
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

    }

}
