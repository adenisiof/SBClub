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
using SBClub.Layers.DLL;

namespace SBClub
{
    /// <summary>
    /// Lógica interna para lancarPontos.xaml
    /// </summary>
    public partial class lancarPontos : Window
    {
        ClientBLL bll = new ClientBLL();
        DTOClientLocal dto = new DTOClientLocal();

        bool cpforip;
        float valorGasto;
        public lancarPontos()
        {
            InitializeComponent();


        }
        private void LancarPontos_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void ckbId_Checked(object sender, RoutedEventArgs e)
        {
            ckbCpf.IsChecked = false;
        }
        private void ckbCpf_Checked(object sender, RoutedEventArgs e)
        {
            ckbId.IsChecked = false;
        }

        //atentica associado
        private void btnAutenticar_Click(object sender, RoutedEventArgs e)
        {

            if (txtNumeroLP.Text != "" && ckbCpf.IsChecked == true || ckbId.IsChecked == true)
            {
                if (ckbCpf.IsChecked == true)
                {
                    dto.Cpf = txtNumeroLP.Text;
                    cpforip = true;
                    txtNome.Text = bll.FindAssociates(dto, cpforip);
                }
                else if (ckbId.IsChecked == true)
                {

                    int login;
                    int.TryParse(txtNumeroLP.Text, out login);
                    dto.Login = login;
                    cpforip = false;
                    txtNome.Text = bll.FindAssociates(dto, cpforip);
                }
                // MessageBox.Show("Preencha valor para ser creditado pontos", "SBClub", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNome.Text = dto.Nome;
            }
            else
            {
                MessageBox.Show("Campos Obrigatorios", "SBClub", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNome.Text = "NOME INVALIDO";
                txtNumeroLP.Focus();
            }
        }

        //lanca pontos do associado
        private void btnLancarLP_Click(object sender, RoutedEventArgs e)
        {

            if (txtValorGasto.Text != "" && cmbFormaPagamento.SelectedIndex != 0 && dto.Nome != "")
            {                
                dto.ValorGasto = txtValorGasto.Text;               
                dto.Pagamento = cmbFormaPagamento.Text;
                dto.LoadFator();
                //call function that insert score
                if (bll.LancaPontoAssociado(dto))
                {
                    MessageBox.Show("Pontos Lançado com sucesso", "SBClub", MessageBoxButton.OK, MessageBoxImage.Information);
                    FormClear();

                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Forma de Pagamento ou valor de compra faltando", "SBClub", MessageBoxButton.OK, MessageBoxImage.Warning);
                //   txtValorGastoLP.Focus();
            }

        }


        private void ValorGasto_Focus(object sender, RoutedEventArgs e)
        {            
                txtValorGasto.Text = "";      

        }

        //clear form
        private void FormClear()
        {
            txtNumeroLP.Text = "";
            ckbCpf.IsChecked = false;
            ckbId.IsChecked = false;
            //  txtValorGastoLP.Text = "";
            //   txtValorGastoLP.Text = "";
            cmbFormaPagamento.SelectedIndex = 0;
        }

        //box login in focus
        private void txtNumeroLP_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNumeroLP.Text = "";
        }

    }
}
