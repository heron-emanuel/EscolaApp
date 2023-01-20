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
    /// Lógica interna para ProfessorWindow.xaml
    /// </summary>
    public partial class ProfessorWindow : Window
    {
        public ProfessorWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            Professor p = new Professor
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                Matricula = txtMatricula.Text,
                Area = txtMatricula.Text
            };

            NProfessor.Inserir(p);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listProfessores.ItemsSource = null;
            listProfessores.ItemsSource = NProfessor.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            Professor p = new Professor
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                Matricula = txtMatricula.Text,
                Area = txtMatricula.Text
            };

            NProfessor.Atualizar(p);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            if (listProfessores.SelectedItem != null)
            {
                NProfessor.Excluir((Professor)listProfessores.SelectedItem);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("Selecione o professor que você quer excluir");
            }
        }

        private void listProfessores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listProfessores.SelectedItem != null)
            {
                Professor p = (Professor)listProfessores.SelectedItem;
                txtId.Text = p.Id.ToString();
                txtNome.Text = p.Nome;
                txtMatricula.Text = p.Matricula;
                txtArea.Text = p.Area;
            }
        }
    }
}
