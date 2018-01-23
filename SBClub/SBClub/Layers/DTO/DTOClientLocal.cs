using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBClub.Layers.DTO
{
    public class DTOClientLocal
    {
        public int Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int Pontos { get; set; }
        public string Pagamento { get; set; }
        public string ValorGasto { get; set; }
        public int id_lojista {get; set;}
        public int fator { get; }


        //sum scores
        public void LoadFator()
        {
            int str = int.Parse(Pagamento.Substring(Pagamento.Length - 3, 1));
            ValorGasto.Replace(".",",");
            double num = double.Parse(ValorGasto);
            num = Math.Round(num);
            Pontos = ((int)num) * str;
        }
           
    }

}
