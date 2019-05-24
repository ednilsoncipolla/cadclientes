using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadClienteTeste.Models
{
    public class Cliente
    {
        string _est_UF;
        string _cid_CodIBGE;
        int _cli_Id;
        string _cli_Nome;
        string _cli_Bairro;
        string _cli_EndEndereço;
        int _cli_EndNumero;
        string _cli_EndComplemento;
        string _cli_Email;
        string _cli_TelResidencial;
        string _Cli_TelCelular;

        /// <summary>
        /// UF, chave estrangeira para tabela de estados
        /// </summary>
        public string Est_UF { get => _est_UF; set => _est_UF = value; }
        /// <summary>
        /// Código do IBE de identificação da cidade
        /// </summary>
        public string Cid_CodIBGE { get => _cid_CodIBGE; set => _cid_CodIBGE = value; }
        /// <summary>
        /// Chave primária da tabela de clientes
        /// </summary>
        public int Cli_Id { get => _cli_Id; set => _cli_Id = value; }
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Cli_Nome { get => _cli_Nome; set => _cli_Nome = value; }
        /// <summary>
        /// Bairro do cliente
        /// </summary>
        public string Cli_Bairro { get => _cli_Bairro; set => _cli_Bairro = value; }
        /// <summary>
        /// Endereço do cliente
        /// </summary>
        public string Cli_EndEndereço { get => _cli_EndEndereço; set => _cli_EndEndereço = value; }
        /// <summary>
        /// Número do endereço do cliente
        /// </summary>
        public int Cli_EndNumero { get => _cli_EndNumero; set => _cli_EndNumero = value; }
        /// <summary>
        /// Complemento do endereço do cliente
        /// </summary>
        public string Cli_EndComplemento { get => _cli_EndComplemento; set => _cli_EndComplemento = value; }
        /// <summary>
        /// e-mail de contato do cliente
        /// </summary>
        public string Cli_Email { get => _cli_Email; set => _cli_Email = value; }
        /// <summary>
        /// Telefone reidencial do cliente
        /// </summary>
        public string Cli_TelResidencial { get => _cli_TelResidencial; set => _cli_TelResidencial = value; }
        /// <summary>
        /// Telefone celular do cliente
        /// </summary>
        public string Cli_TelCelular { get => _Cli_TelCelular; set => _Cli_TelCelular = value; }
    }
}