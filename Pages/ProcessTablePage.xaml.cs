using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NeknajStudyManager
{
    public partial class ProcessTablePage : ContentPage
    {
        public ProcessTablePage()
        {
            InitializeComponent();
            NavigationPage.SetTitleView(this, new Button { Text = "Back", Command = new Command(() => Navigation.PopAsync()) });
        }
    }

}
