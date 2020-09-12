using SchoolTableCursed.DB_Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        private SubjTableDataSetTableAdapters.ExerciseTableAdapter subjTableDataSetExerciseTableAdapter;
        private CollectionViewSource schoolTableViewSource;

        private SchoolTableContext schoolContext;



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

            #region ExerciseViewSource

            // Загрузить данные в таблицу Exercise. Можно изменить этот код как требуется.

            subjTableDataSetExerciseTableAdapter = new SubjTableDataSetTableAdapters.ExerciseTableAdapter();
            //subjTableDataSetExerciseTableAdapter.Fill(subjTableDataSet.Exercise);

            ObservableCollection<Exercise> query = new ObservableCollection<Exercise>(schoolContext.Exercise);

            //System.Windows.Data.CollectionViewSource exerciseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exerciseViewSource")));
            schoolTableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exerciseViewSource")));

            schoolTableViewSource.Source = query;
            schoolTableViewSource.Filter += CollectionViewSource_Calendar_Filter;
            schoolTableViewSource.Filter += CollectionViewSource_Subj_Filter;
            schoolTableViewSource.Filter += CollectionViewSource_Teacher_Filter;
            schoolTableViewSource.Filter += CollectionViewSource_Group_Filter;
            schoolTableViewSource.Filter += CollectionViewSource_Class_Filter;
            schoolTableViewSource.Filter += CollectionViewSource_Kind_Filter;
            schoolTableViewSource.Filter += CollectionViewSource_Week_Filter;
            //exerciseViewSource.View.MoveCurrentToFirst();

            #endregion


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

        private string TimeCast(DateTime date)
        {
            var dateTime = date.DayOfWeek;
            string _date;
            switch (dateTime)
            {
                case (DayOfWeek)1:
                    _date = "пн";
                    break;

                case (DayOfWeek)2:
                    _date = "вт";
                    break;

                case (DayOfWeek)3:
                    _date = "ср";
                    break;

                case (DayOfWeek)4:
                    _date = "чт";
                    break;

                case (DayOfWeek)5:
                    _date = "пт";
                    break;

                case (DayOfWeek)6:
                    _date = "сб";
                    break;

                case (DayOfWeek)7:
                    _date = "вс";
                    break;

                default:
                    _date = "";
                    break;
            }

            return _date;
        }



        #region DataChangesEvents
        private void CalendarValue_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(exerciseDataGrid.ItemsSource).Refresh();
        }

        #endregion

        #region CollectionFilteringFunctions
        private void CollectionViewSource_Calendar_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                string day = TimeCast(calendarValue.SelectedDate ?? DateTime.Today);

                if (t.DayOfWeek.Equals(day))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }

        private void CollectionViewSource_Subj_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                DataRowView dataRow = (subjCB.SelectedItem as DataRowView);
                string subj = string.Empty;

                if (dataRow != null)
                    subj = dataRow["SubjName"] as string;

                if (!t.SubjNameFK.Equals(subj) && !string.IsNullOrEmpty(subj))
                    e.Accepted = false;
            }
        }

        private void CollectionViewSource_Teacher_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                DataRowView dataRow = (teacherCB.SelectedItem as DataRowView);
                string teacher = string.Empty;

                if (dataRow != null)
                    teacher = dataRow["FullName"] as string;

                if (!t.TeacherFK.Equals(teacher) && !string.IsNullOrEmpty(teacher))
                    e.Accepted = false;
            }
        }

        private void CollectionViewSource_Group_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                DataRowView dataRow = (groupCB.SelectedItem as DataRowView);
                string group = string.Empty;
                    
                if (dataRow != null)
                    group = dataRow["GroupName"] as string;

                if (!t.GroupFK.Equals(group) && !string.IsNullOrEmpty(group))
                    e.Accepted = false;
            }
        }

        private void CollectionViewSource_Class_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                DataRowView dataRow = (classCB.SelectedItem as DataRowView);
                string cabinet = string.Empty;

                if (dataRow != null)
                    cabinet = dataRow["Class"] as string;

                if (!t.Class.Equals(cabinet) && !string.IsNullOrEmpty(cabinet))
                    e.Accepted = false;
            }
        }

        private void CollectionViewSource_Kind_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                DataRowView dataRow = (kindCB.SelectedItem as DataRowView);
                string kind = string.Empty;

                if (dataRow != null)
                    kind = dataRow["ExKind"] as string;

                if (!t.ExKind.Equals(kind) && !string.IsNullOrEmpty(kind))
                    e.Accepted = false;
            }
        }

        private void CollectionViewSource_Week_Filter(object sender, FilterEventArgs e)
        {
            // If filter is turned on, filter completed items.
            if (e.Item is Exercise t)
            {
                DataRowView dataRow = (weekCB.SelectedItem as DataRowView);
                string week = string.Empty;

                if (dataRow != null)
                    week = dataRow["WeekType"] as string;

                if (!t.AWeek.Equals(week) && !string.IsNullOrEmpty(week))
                    e.Accepted = false;
            }
        }
        #endregion

    }
}



/*
 TODO
 вид занятия && кабинет combobox
 Кнопку LogIn    
 */
