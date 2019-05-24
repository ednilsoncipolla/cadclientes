using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadClienteTeste.Models
{
    public class Cidade
    {
        string _est_UF;
        string _Cid_CodIBGE;
        string _Cid_Nome;
        /// <summary>
        /// UF, chave estrangeira para tabela de estados
        /// </summary>
        public string Est_UF { get => _est_UF; set => _est_UF = value; }
        /// <summary>
        /// Código do IBE de identificação da cidade
        /// </summary>
        public string Cid_CodIBGE { get => _Cid_CodIBGE; set => _Cid_CodIBGE = value; }
        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Cid_Nome { get => _Cid_Nome; set => _Cid_Nome = value; }
    }
}