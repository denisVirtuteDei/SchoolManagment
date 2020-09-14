using System;
using System.Collections.Generic;
using System.Data;
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
using SchoolTableCursed.DB_Classes;
using SchoolTableCursed.UserWindow;
using SchoolTableCursed.AdministratorWindow.Pages;

namespace SchoolTableCursed.AdministratorWindow
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private DB_Classes.SchoolTableContext context;
        public TabNavigator Navigator { get; private set; }

        public AdminWindow()
        {
            InitializeComponent();

            context = new DB_Classes.SchoolTableContext();

            Navigator = new TabNavigator
            {
                Element = new Pages.ExercisePage()
            };

            Frame frame = new Frame
            {
                Content = Navigator.Element
            };

            AddTab.Content = frame;
            EditTab.Content = frame;
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

        private void AddTab_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditTab_Selected(object sender, RoutedEventArgs e)
        {
            
        }


        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (exerciseDataGrid.SelectedIndex != -1)
            {
                RemoveExercise();
            }
        }

        private void DB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame frame = new Frame
            {
                Content = Navigator.Element
            };

            (ActList.SelectedItem as TabItem).Content = frame;
        }

        #region RemoveFunctions
        private void RemoveExercise()
        {
            if (exerciseDataGrid.SelectedItem is DataRowView t)
            {
                var id = (int)t.Row[0];



                var customer = context.Exercise
                        .Where(p => p.ExID == id)
                        .FirstOrDefault();

                context.Exercise.Attach(customer);
                context.Exercise.Remove(customer);
                context.SaveChanges();

                MessageBox.Show("Good job! id = " + customer.ExID.ToString());

                exerciseDataGrid.Items.Refresh();
                exerciseDataGrid.SelectedIndex = -1;
            }
        }


        #endregion

        #region Tab_Selected
        private void ExerciseTab_Selected(object sender, RoutedEventArgs e)
        {
            Navigator.Element = new Pages.ExercisePage();
        }

        private void GroupTab_Selected(object sender, RoutedEventArgs e)
        {
            Navigator.Element = new Pages.GroupPage();
        }

        private void SubjectTab_Selected(object sender, RoutedEventArgs e)
        {
            Navigator.Element = new Pages.SubjectPage();
        }

        private void TeacherTab_Selected(object sender, RoutedEventArgs e)
        {
            Navigator.Element = new Pages.TeacherPage();
        }
        #endregion

        private void exerciseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var aaa = (ActList.SelectedItem as TabItem);

            //if (aaa != null)
            //    if (exerciseDataGrid.SelectedIndex != 0 && aaa.Name.Equals("EditTab"))
            //    {
            //        (Navigator.Element as Pages.ExercisePage).PageFill(exerciseDataGrid.SelectedItem as DataRowView);
            //    }
        }

        private void groupDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
