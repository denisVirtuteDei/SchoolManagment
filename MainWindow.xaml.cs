using SchoolTableCursed.DB_Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
        private CollectionViewSource schoolTableViewSource;
        private bool subjCB = false, teacherCB = false,
                     groupCB = false;


        public MainWindow()
        {
            InitializeComponent();

            schoolContext = new SchoolTableContext();
        }

        private void LogInLink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubjTableDataSet subjTableDataSet = ((SubjTableDataSet)(this.FindResource("subjTableDataSet")));

            // Загрузить данные в таблицу Exercise. Можно изменить этот код как требуется.

            //subjTableDataSetExerciseTableAdapter.Fill(subjTableDataSet.Exercise);
            //System.Windows.Data.CollectionViewSource exerciseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exerciseViewSource")));
            SubjTableDataSetTableAdapters.ExerciseTableAdapter subjTableDataSetExerciseTableAdapter = new SubjTableDataSetTableAdapters.ExerciseTableAdapter();
            ObservableCollection<Exercise> query = new ObservableCollection<Exercise>(schoolContext.Exercise);
            schoolTableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exerciseViewSource")));
            schoolTableViewSource.Source = query;
            schoolTableViewSource.Filter += CollectionViewSource_Filter;
            //exerciseViewSource.View.MoveCurrentToFirst();

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

        private void CalendarValue_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(exerciseDataGrid.ItemsSource).Refresh();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                string day = TimeCast(calendarValue.SelectedDate.GetValueOrDefault().DayOfWeek);

                if (t.DayOfWeek.Equals(day))
                    e.Accepted = false;
                else
                    e.Accepted = true;
            }
        }

        private string TimeCast(DayOfWeek dateTime)
        {
            string date;
            switch (dateTime)
            {
                case (DayOfWeek)1:
                    date = "пн";
                    break;

                case (DayOfWeek)2:
                    date = "вт";
                    break;

                case (DayOfWeek)3:
                    date = "ср";
                    break;

                case (DayOfWeek)4:
                    date = "чт";
                    break;

                case (DayOfWeek)5:
                    date = "пт";
                    break;

                case (DayOfWeek)6:
                    date = "сб";
                    break;

                case (DayOfWeek)7:
                    date = "вс";
                    break;

                default:
                    date = "";
                    break;
            }

            return date;
        }

        private void SubjComboBox_DataChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(exerciseDataGrid.ItemsSource).Refresh();
        }
    }
}



/*
 TODO
 Фильтрация по Combobox'ам
 Кнопку LogIn
 Посмотреть Генератор записей для бд     
 */
