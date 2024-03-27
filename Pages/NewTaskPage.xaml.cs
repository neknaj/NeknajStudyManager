
namespace NeknajStudyManager
{
    public partial class NewTaskPage : ContentPage
    {

        public NewTaskPage()
        {
            InitializeComponent();
        }


        public void SetSubjectEntry(object sender, EventArgs e)
        {
            if (SubjectEntrySuggestions.SelectedIndex!=-1) { 
                SubjectEntry.Text = SubjectEntrySuggestions.SelectedItem.ToString();
            }
            SubjectEntrySuggestions.SelectedIndex = -1;
        }
        public void ChangeTaskNameEntryType(object sender, EventArgs e)
        {
            if (TaskNameEntryTypeSelector.SelectedIndex != -1)
            {
                if (TaskNameEntryTypeSelector.SelectedIndex == 1)
                {
                    TaskNameEntry_ISBN.IsVisible = false;
                    TaskNameEntry_Name.IsVisible = true;
                }
                else
                {
                    TaskNameEntry_ISBN.IsVisible = true;
                    TaskNameEntry_Name.IsVisible = false;
                }
            }
            TaskNameEntryTypeSelector.SelectedIndex = -1;
        }
        public void SetTimeLimitTypeEntry(object sender, EventArgs e)
        {
            if (TimeLimitTypeEntrySuggestions.SelectedIndex != -1)
            {
                TimeLimitTypeEntry.Text = TimeLimitTypeEntrySuggestions.SelectedItem.ToString();
            }
            TimeLimitTypeEntrySuggestions.SelectedIndex = -1;
        }
        public void SetTaskOriginEntry(object sender, EventArgs e)
        {
            if (TaskOriginEntrySuggestions.SelectedIndex != -1)
            {
                TaskOriginEntry.Text = TaskOriginEntrySuggestions.SelectedItem.ToString();
            }
            TaskOriginEntrySuggestions.SelectedIndex = -1;
        }
        public void SetTaskFormEntry(object sender, EventArgs e)
        {
            if (TaskFormEntrySuggestions.SelectedIndex != -1)
            {
                TaskFormEntry.Text = TaskFormEntrySuggestions.SelectedItem.ToString();
            }
            TaskFormEntrySuggestions.SelectedIndex = -1;
        }

    }

}
