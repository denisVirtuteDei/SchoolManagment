using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using SchoolTableCursed.UserWindow;

namespace SchoolTableCursed.AdministratorWindow
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            SchoolTableCursed.SubjTableDataSet subjTableDataSet = ((SchoolTableCursed.SubjTableDataSet)(this.FindResource("subjTableDataSet")));
            // Загрузить данные в таблицу Exercise. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.ExerciseTableAdapter subjTableDataSetExerciseTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.ExerciseTableAdapter();
            subjTableDataSetExerciseTableAdapter.Fill(subjTableDataSet.Exercise);
            System.Windows.Data.CollectionViewSource exerciseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exerciseViewSource")));
            exerciseViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Groups. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.GroupsTableAdapter subjTableDataSetGroupsTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.GroupsTableAdapter();
            subjTableDataSetGroupsTableAdapter.Fill(subjTableDataSet.Groups);
            System.Windows.Data.CollectionViewSource groupsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("groupsViewSource")));
            groupsViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Subject. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.SubjectTableAdapter subjTableDataSetSubjectTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.SubjectTableAdapter();
            subjTableDataSetSubjectTableAdapter.Fill(subjTableDataSet.Subject);
            System.Windows.Data.CollectionViewSource subjectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("subjectViewSource")));
            subjectViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Teacher. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.TeacherTableAdapter subjTableDataSetTeacherTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.TeacherTableAdapter();
            subjTableDataSetTeacherTableAdapter.Fill(subjTableDataSet.Teacher);
            System.Windows.Data.CollectionViewSource teacherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("teacherViewSource")));
            teacherViewSource.View.MoveCurrentToFirst();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            App.Current.MainWindow = mainW;
            mainW.Show();
            this.Close();
        }

        private void FlightsTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExerciseDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTab_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void EditTab_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DBList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
