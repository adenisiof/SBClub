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
using System.Data;
using SBClub.Layers.DLL;

namespace SBClub
{
    /// <summary>
    /// Lógica interna para Planos.xaml
    /// </summary>
    public partial class Planos : Window
    {
        public Planos()
        {
            InitializeComponent();
            ClientBLL bll = new ClientBLL();

            //database to insert view plan, this report to app plans content in table planos of database sbclubd
            DataTable dataTable = new DataTable();
            dataTable = bll.LoadPlanos();
            int rows = dataTable.Rows.Count;
            rows -= 1;

            //load datatable and launch in screen to user to see
            if (rows >= 0)
            {
                    txtPlano_1.Text = dataTable.Rows[0][0].ToString();
                    txtPlano_2.Text = dataTable.Rows[0][2].ToString();
                    txtPlano_3.Text = dataTable.Rows[0][4].ToString();
                    txtPlano_4.Text = dataTable.Rows[0][6].ToString();

                    txtTipo_1.Text = dataTable.Rows[0][1].ToString();
                    txtTipo_2.Text = dataTable.Rows[0][3].ToString();
                    txtTipo_3.Text = dataTable.Rows[0][5].ToString();
                    txtTipo_4.Text = dataTable.Rows[0][7].ToString();

            }
            else
            {
                MessageBox.Show("Não existe planos cadastrados para esse usuário\nContacte o Administrador SBClub", "SBClub", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnVoltarPlanos_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
