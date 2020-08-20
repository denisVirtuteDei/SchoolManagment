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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolTableCursed
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInLink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            SchoolTableCursed.SubjTableDataSet subjTableDataSet = ((SchoolTableCursed.SubjTableDataSet)(this.FindResource("subjTableDataSet")));
            // Загрузить данные в таблицу Exercise. Можно изменить этот код как требуется.
            SchoolTableCursed.SubjTableDataSetTableAdapters.ExerciseTableAdapter subjTableDataSetExerciseTableAdapter = new SchoolTableCursed.SubjTableDataSetTableAdapters.ExerciseTableAdapter();
            subjTableDataSetExerciseTableAdapter.Fill(subjTableDataSet.Exercise);
            System.Windows.Data.CollectionViewSource exerciseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exerciseViewSource")));
            exerciseViewSource.View.MoveCurrentToFirst();
        }
    }
}
