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
using SBClub.Layers.DTO;
using SBClub.Layers.DAL;
using SBClub.Layers.DLL;

namespace SBClub
{
    public partial class Configuracao : Window
    {
        DTOClientLocal dto = new DTOClientLocal();
        ClientBLL bll = new ClientBLL();
        MainWindow win = new MainWindow();
        private bool enablebtn = false;
        
        public Configuracao(bool btnable, bool btnAutentica)
        {
            InitializeComponent();
            enablebtn = btnable;
            btnConfigVerPlano.IsEnabled = btnAutentica;
        }

        private void btnConfigAutenticar_Click(object sender, RoutedEventArgs e)
        {            
            int valorInteiro;

            //verify value is integer
            bool isNumeroInteiro = int.TryParse(txbLoginName.Text, out valorInteiro);
            
            if (isNumeroInteiro &&  txbLoginSenha.Text != "" && txbLoginName.Text != "")
            {
                dto.Login = valorInteiro;
                dto.Senha = txbLoginSenha.Text;
                enablebtn = bll.InsertDbLocal(dto, enablebtn);
                this.Close();
                //anable buttons of initial screen 

                win.HabilitaButons(enablebtn);
                win.Show();
            }
            else
            {
                MessageBox.Show("Valores Digitados ivalidos ");
                txbLoginName.Text = "";
                txbLoginSenha.Text = "";
                txbLoginName.Focus();
            }

        }

        private void btnConfigVerPlano_Click(object sender, RoutedEventArgs e)
        {           
            Planos planos = new Planos();
            planos.ShowDialog();
        }


    }
}
