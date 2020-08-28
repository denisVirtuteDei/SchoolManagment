using SchoolTableCursed.DB_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolTableCursed
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SchoolTableContext schoolContext;
        //private List<Groups> Groups { get; set; }



        public MainWindow()
        {
            InitializeComponent();



            schoolContext = new SchoolTableContext();
            
            //var item = schoolManagContext.Groups.ToList();
            //Groups = item;
            //DataContext = Groups;

        }

        private void LogInLink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubjTableDataSet subjTableDataSet = ((SubjTableDataSet)(this.FindResource("subjTableDataSet")));
            
            // Загрузить данные в таблицу Exercise. Можно изменить этот код как требуется.
            SubjTableDataSetTableAdapters.ExerciseTableAdapter subjTableDataSetExerciseTableAdapter = new SubjTableDataSetTableAdapters.ExerciseTableAdapter();
            subjTableDataSetExerciseTableAdapter.Fill(subjTableDataSet.Exercise);
            System.Windows.Data.CollectionViewSource exerciseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exerciseViewSource")));
            exerciseViewSource.View.MoveCurrentToFirst();
            
            // Загрузить данные в таблицу Subject. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.SubjectTableAdapter subjTableDataSetSubjectTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.SubjectTableAdapter();
            subjTableDataSetSubjectTableAdapter.Fill(subjTableDataSet.Subject);
            System.Windows.Data.CollectionViewSource subjectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("subjectViewSource")));
            subjectViewSource.View.MoveCurrentToFirst();
            
            // Загрузить данные в таблицу Groups. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.GroupsTableAdapter subjTableDataSetGroupsTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.GroupsTableAdapter();
            subjTableDataSetGroupsTableAdapter.Fill(subjTableDataSet.Groups);
            System.Windows.Data.CollectionViewSource groupsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("groupsViewSource")));
            groupsViewSource.View.MoveCurrentToFirst();
            
            // Загрузить данные в таблицу Teacher. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.TeacherTableAdapter subjTableDataSetTeacherTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.TeacherTableAdapter();
            subjTableDataSetTeacherTableAdapter.Fill(subjTableDataSet.Teacher);
            System.Windows.Data.CollectionViewSource teacherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("teacherViewSource")));
            teacherViewSource.View.MoveCurrentToFirst();
            
            // Загрузить данные в таблицу Week. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.WeekTableAdapter subjTableDataSetWeekTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.WeekTableAdapter();
            subjTableDataSetWeekTableAdapter.Fill(subjTableDataSet.Week);
            System.Windows.Data.CollectionViewSource weekViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("weekViewSource")));
            weekViewSource.View.MoveCurrentToFirst();
        }

        private void calendarValue_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //SubjTableDataSet subjTableDataSet = ((SubjTableDataSet)(this.FindResource("subjTableDataSet")));
                        
            CollectionViewSource.GetDefaultView(exerciseDataGrid.ItemsSource).Refresh();
            

        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            //calendarValue.SelectedDate.Value.DayOfWeek

            Exercise t = e.Item as Exercise;
            
            // If filter is turned on, filter completed items.
            if (t != null)
            {
                if (t.DayOfWeek.Equals(calendarValue.SelectedDate.Value.DayOfWeek.ToString()))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }

        }
    }
}
