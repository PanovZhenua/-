using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Индивидуальный_Проект
{
    public partial class Отчёт_об_ошибках : Page
    {
        private ObservableCollection<BugReport> bugReports;

        public Отчёт_об_ошибках(int userId)
        {
            InitializeComponent();
            LoadBugReports();
        }

        private void LoadBugReports()
        {
            using (MDZEntities db = new MDZEntities())
            {
                bugReports = new ObservableCollection<BugReport>(db.BugReport);
                BugReportDataGrid.ItemsSource = bugReports;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BugReportDataGrid.SelectedItem is BugReport selectedBugReport)
            {
                using (MDZEntities db = new MDZEntities())
                {
                    var bugToDelete = db.BugReport.Find(selectedBugReport.BugID);
                    if (bugToDelete != null)
                    {
                        db.BugReport.Remove(bugToDelete);
                        db.SaveChanges();
                        bugReports.Remove(selectedBugReport);
                    }
                }
            }
        }

        private void FixButton_Click(object sender, RoutedEventArgs e)
        {
            if (BugReportDataGrid.SelectedItem is BugReport selectedBugReport)
            {
                using (MDZEntities db = new MDZEntities())
                {
                    var bugToFix = db.BugReport.Find(selectedBugReport.BugID);
                    if (bugToFix != null)
                    {
                        bugToFix.IsFixed = !bugToFix.IsFixed;
                        db.SaveChanges();
                        selectedBugReport.IsFixed = bugToFix.IsFixed;
                        LoadBugReports();
                    }
                }
            }
        }
        
    }
}
