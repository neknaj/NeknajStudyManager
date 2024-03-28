using System.Collections.ObjectModel;

namespace NeknajStudyManager
{
    public partial class TaskTablePage : ContentPage
    {
        public ObservableCollection<TaskTable> TaskTableData { get; set; }
        public TaskTablePage()
        {
            InitializeComponent();
            NavigationPage.SetTitleView(this, new Button { Text = "Back", Command = new Command(() => Navigation.PopAsync()) });
            UpdateTable();
        }
        public async Task<int> UpdateTable()
        {
            var strage = new DataStrage();
            await strage.ClearTaskAsync();
            await strage.InsertTaskAsync(new TaskTable {
                Subject = "数学",
                TimeLimit = DateTime.Now,
                TimeLimitType = "絶対",
                ISBN = "9780000000000",
                Range_start = 10,
                Range_end = 15,
                Range_unit = "ページ",
                Status = "実行中",
                Memo = "メモ",
                Origin = "自習",
                Type = "問題集",
            });
            await strage.InsertTaskAsync(new TaskTable
            {
                Subject = "国語",
                TimeLimit = DateTime.Now,
                TimeLimitType = "自習",
                Name = "古文単語",
                Range_start = 0,
                Range_end = 15,
                Range_unit = "語",
                Status = "中断",
                Memo = "メモ",
                Origin = "自習",
                Type = "単語帳",
            });
            TaskTableView.ItemsSource = await strage.GetAllTasksAsync();
            return 0;
        }

    }

}
