using BDSqlServer;
using System.Collections.Generic;
using System.Data;

namespace CadClientes.Models
{
    /// <summary>
    /// Repositorio de acesso a tabela de Estados
    /// </summary>
    public static class EstadoRepository
    {
        /// <summary>
        /// Inclui um novo estado no banco de dados
        /// </summary>
        /// <param name="estado">Estado a ser inserido</param>
        public static void setIncluir (Estado estado)
        {
            if (string.IsNullOrEmpty(estado.Est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "UF");

            if (string.IsNullOrEmpty(estado.Est_Nome))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Nome do estado");

            string sSql = $"spEstadoIncluir '{estado.Est_UF}','{estado.Est_Nome}'";

            BDSqlServer.BD.executaComando(sSql);
        }

        /// <summary>
        /// Altera os dados do estado 
        /// </summary>
        /// <param name="estado">Estado a ser salvo</param>
        public static void setAlterar(Estado estado)
        {
            if (string.IsNullOrEmpty(estado.Est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "UF");

            if (string.IsNullOrEmpty(estado.Est_Nome))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Nome do estado");

            string sSql = $"spEstadoAlterar '{estado.Est_UF}','{estado.Est_Nome}'";

            BDSqlServer.BD.executaComando(sSql);
        }

        /// <summary>
        /// Exclui o Estado
        /// </summary>
        /// <param name="estado">Estado a ser exluído</param>
        public static void setExcluir(Estado estado)
        {
            if (string.IsNullOrEmpty(estado.Est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "UF");

            string sSql = $"spEstadoExcluir '{estado.Est_UF}'";

            BD.executaComando(sSql);
        }

        /// <summary>
        /// Recupera lista de estados
        /// </summary>
        /// <param name="where">Critério de pesquisa a ser aplicado na clausula where</param>
        /// <returns>Lista tipara de Estados</returns>
        public static List<Estado> getEstados(string where = "")
        {
            List<Estado> listaEstados = new List<Estado>();

            string sSql = $"select * from vwEstados {(string.IsNullOrEmpty(where) ? "" : $"where {where}")}";

            using (DataTable dt = BD.getDataTable(sSql))
            {
                if (dt.Rows.Count == 0)
                {
                    listaEstados.Add(new Estado());
                }
                else
                    foreach (DataRow dr in dt.Rows)
                    {
                        listaEstados.Add(
                            new Estado
                            {
                                Est_UF = dr["Est_UF"].ToString(),
                                Est_Nome = dr["Est_Nome"].ToString()
                            }
                        );
                    }
            }
            return listaEstados;
        }

        /// <summary>
        /// Recupera um estado 
        /// </summary>
        /// <param name="est_UF">UF do estado a ser recuperado</param>
        /// <returns>Estado recuperado ou NULL se não localizar a UF</returns>
        public static Estado getEstado(string est_UF)
        {
            if (string.IsNullOrEmpty(est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Est_UF");


            string sSql = $"select * from vwEstados where Est_UF = '{est_UF}'";

            using (DataTable dt = BD.getDataTable(sSql))
            {
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return new Estado
                    {
                        Est_UF = dt.Rows[0]["Est_UF"].ToString() ,
                        Est_Nome = dt.Rows[0]["Est_Nome"].ToString()
                    };
                }
            }
        }
    }
}