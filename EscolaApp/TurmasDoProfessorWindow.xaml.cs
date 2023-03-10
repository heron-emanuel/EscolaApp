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

namespace EscolaApp
{
    /// <summary>
    /// Lógica interna para TurmasDoProfessorWindow.xaml
    /// </summary>
    public partial class TurmasDoProfessorWindow : Window
    {
        public TurmasDoProfessorWindow()
        {
            InitializeComponent();
            listProfessores.ItemsSource = NProfessor.Listar();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            if (listProfessores.SelectedItem != null)
            {
                Professor p = (Professor)listProfessores.SelectedItem;
                listTurmas.ItemsSource = null;
                listTurmas.ItemsSource = NTurma.Listar(p);
            }
            else
                MessageBox.Show("É preciso selecionar um professor");
        }
    }
}
