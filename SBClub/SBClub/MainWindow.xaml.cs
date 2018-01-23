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
using System.Xaml;

namespace SBClub
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
       private bool btnable = false;
       private bool btnAutentica = false;
       
        public MainWindow()
        {
            InitializeComponent();
            string data = DateTime.Now.ToString();
            btnMainConfig.IsEnabled = true;
            HabilitaButons(btnable);
        }
       

        public bool Btnable
        {
            get { return btnable; }
            set { btnable = value; }
        }

        private void btnMainConfig_Click(object sender, RoutedEventArgs e)
        {
            Configuracao config = new Configuracao(btnable, btnAutentica);
            config.Show();
            this.Close();
        }

        private void btnMainLancarPontos_Click(object sender, RoutedEventArgs e)
        {
            lancarPontos lPtn = new lancarPontos();
            lPtn.Show();
        }

        private void btnMainVerResumo_Click(object sender, RoutedEventArgs e)
        {
            Resumo res = new Resumo();
            res.Show();
        }

       public void HabilitaButons(bool ativa)
        {
            btnAutentica = ativa;
            if (ativa)            {
               
                btnMainLancarPontos.IsEnabled = true;
                btnMainVerResumo.IsEnabled = true;
            }
            else
            {
                btnMainLancarPontos.IsEnabled = false;
                btnMainVerResumo.IsEnabled = false;
                
            }

        }
    }
}
