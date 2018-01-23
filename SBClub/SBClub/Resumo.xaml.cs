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
    /// Lógica interna para Resumo.xaml
    /// </summary>
    public partial class Resumo : Window
    {
        ClientBLL bll = new ClientBLL();
        public Resumo()
        {
            InitializeComponent();
            ResunmoClent();
        }


        private void BtnResumo_click(object sender, RoutedEventArgs e)
        {

        }

        public void ResunmoClent()
        {
            int ids;
            int amountShowRegisters = 0;
            DataTable dt = bll.RetResumo();
            DataTable dataAux = bll.RetResumo();



            int amountRegisters = dt.Rows.Count;  //recebe quantidades de registros do datatable
            amountShowRegisters = amountRegisters - 1;  //variavel que guarda valor inicial
            ids = amountRegisters;
            //percorrendo datatable para inverter posições, ultimo passa a ser o primeiro
            for (int row = 0; row <= amountShowRegisters; row++) 
            {
                amountRegisters--;
                int amountCamp = dt.Columns.Count;
                for (int column = 0; column <= amountCamp; column++)
                {
                    amountCamp--;
                    dataAux.Rows[row][column] = dt.Rows[amountRegisters][column];  //jogando ultimo para primeiro                  
                }
            }

            StackPanel[] panel = new StackPanel[ids];       //onde vamos mostrar o valores 
            Label[] valor = new Label[ids];
            Label[] pontos = new Label[ids];
            Label[] cpf = new Label[ids];
            Label[] data = new Label[ids];

            float x = 50f, y = 0f, xlbl = 0, ylbl = 0;     //posição em realção aos pontos iniciais

          
            //Creating left informations with value and scores
            for (int i = 0; i < ids; i++)
            {
                panel[i] = new StackPanel() { Width = 140, Height = 50, VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(x, y, 1, 0) };
                if (i % 2 == 0)
                {
                    panel[i].Background = Brushes.Gray;
                }
                else
                {
                    panel[i].Background = Brushes.DarkGray;
                }
                
                gMain.Children.Add(panel[i]);
                

                valor[i] = new Label() { Content = "R$ " + dataAux.Rows[i][3].ToString(), Width = 100, Height = 16, VerticalContentAlignment = VerticalAlignment.Top, FontSize = 12, FontWeight = FontWeights.ExtraBold, HorizontalContentAlignment = HorizontalAlignment.Center, Foreground = Brushes.Black, Padding = new Thickness(2, 1, 1, 1), Margin = new Thickness(xlbl, 0, 0, 0) };
                pontos[i] = new Label() { Content = "Pontos: " + dataAux.Rows[i][1].ToString(), Width = 100, Height = 16, FontSize = 10, FontWeight = FontWeights.ExtraBold, VerticalContentAlignment = VerticalAlignment.Top, HorizontalContentAlignment = HorizontalAlignment.Center, Foreground = Brushes.Black, Padding = new Thickness(2, 1, 1, 1), Margin = new Thickness(xlbl, 0, 0, 0) };

                panel[i].Children.Add(valor[i]);
                panel[i].Children.Add(pontos[i]);
                y += 35f;

            }

            x = 200f;
            y = 0f;

            //creating rigth informations with date and cpf
            for (int i = 0; i < ids; i++)
            {


                panel[i] = new StackPanel() { Width = 200, Height = 50, VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(x, y, 40, 40) };
                if (i % 2 == 0)
                {
                    panel[i].Background = Brushes.Gray;
                }
                else
                {
                    panel[i].Background = Brushes.DarkGray;
                }
                gMain.Children.Add(panel[i]);


                data[i] = new Label() { Content = dataAux.Rows[i][2].ToString(), Width = 120, Height = 16, VerticalContentAlignment = VerticalAlignment.Top, FontSize = 12, FontWeight = FontWeights.ExtraBold, HorizontalContentAlignment = HorizontalAlignment.Left, Foreground = Brushes.Black, Padding = new Thickness(2, 1, 1, 1), Margin = new Thickness(xlbl, 0, 0, 0) };
                cpf[i] = new Label() { Content = "Doc : " + dataAux.Rows[i][0].ToString(), Width = 120, Height = 16, FontSize = 10, FontWeight = FontWeights.ExtraBold, VerticalContentAlignment = VerticalAlignment.Top, HorizontalContentAlignment = HorizontalAlignment.Left, Foreground = Brushes.Black, Padding = new Thickness(2, 1, 1, 1), Margin = new Thickness(xlbl, 0, 0, 0) };

                panel[i].Children.Add(data[i]);
                panel[i].Children.Add(cpf[i]);
                y += 35f;

            }

        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
