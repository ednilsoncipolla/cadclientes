using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadClientes.Models
{
    public class Estado
    {
        private string _est_UF;
        private string _est_Nome;

        /// <summary>
        /// Codigo de idenficação da Unidade Federativa
        /// </summary>
        [Display(Name = "UF")]
        public string Est_UF { get => _est_UF; set => _est_UF = value; }

        /// <summary>
        /// Nome da Unidade Federativa
        /// </summary>
        [Display(Name = "Nome")]
        public string Est_Nome { get => _est_Nome; set => _est_Nome = value; }
    }
}
