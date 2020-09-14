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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolTableCursed.AdministratorWindow.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExercisePage.xaml
    /// </summary>
    public partial class ExercisePage : Page
    {
        private DB_Classes.SchoolTableContext context;
        private DB_Classes.Exercise exercise = null;
        public ExercisePage()
        {
            InitializeComponent();
            context = new DB_Classes.SchoolTableContext();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {


            //exercise.AWeek = AWeekComboBox.Text;
            //exercise.Class = Convert.ToInt32(CabinetBox.Text);
            //exercise.DayOfWeek = DayOfWeekBox.Text;
            //exercise.ExKind = KindComboBox.Text;
            //exercise.ExNumber = Convert.ToInt32(SubjNumberComboBox.Text);
            //exercise.SubjNameFK = SubjNameBox.Text;
            //exercise.TeacherFK = TeacherFullNameComboBox.Text;


            //CabinetBox.Text = "";
            //DayOfWeekBox.Text = "";
            //SubjNameBox.Text = "";
            //SubjNumberComboBox.SelectedIndex = -1;

            //context.SaveChanges();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SubjTableDataSet subjTableDataSet = ((SubjTableDataSet)(this.FindResource("subjTableDataSet")));

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

        public void PageFill(DataRowView dataRow)
        {
            //if(dataRow != null)
            //{
            //    var id = (int)dataRow.Row[0];

            //    exercise = context.Exercise
            //            .Where(p => p.ExID == id)
            //            .FirstOrDefault();

            //    CabinetBox.Text = exercise.Class.ToString();
            //    DayOfWeekBox.Text = exercise.DayOfWeek;
            //    SubjNameBox.Text = exercise.SubjNameFK;
            //}
        }
    }
}
