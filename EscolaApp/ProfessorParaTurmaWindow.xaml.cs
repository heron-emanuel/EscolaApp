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
    /// Lógica interna para ProfessorParaTurmaWindow.xaml
    /// </summary>
    public partial class ProfessorParaTurmaWindow : Window
    {
        public ProfessorParaTurmaWindow()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listTurmas.ItemsSource = null;
            listTurmas.ItemsSource = NTurma.Listar();
            listProfessores.ItemsSource = null;
            listProfessores.ItemsSource = NProfessor.Listar();
        }

        private void AtribuirClick(object sender, RoutedEventArgs e)
        {
            if (listTurmas.SelectedItem != null &&
                listProfessores.SelectedItem != null)
            {
                Professor p = (Professor)listProfessores.SelectedItem;
                Turma t = (Turma)listTurmas.SelectedItem;
                NTurma.CadastrarProfessor(p, t);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("É preciso selecionar um professor e uma turma");
            }
        }
    }
}
