using BDSqlServer;
using System.Collections.Generic;
using System.Data;

namespace CadClienteTeste.Models
{
    /// <summary>
    /// Repositorio de acesso a tabela de Cidades
    /// </summary>
    public static class CidadeRepository
    {
        /// <summary>
        /// Inclui uma nova cidade no banco de dados
        /// </summary>
        /// <param name="cidade">cidade a ser inserida</param>
        public static void setIncluir(Cidade cidade)
        {
            if (string.IsNullOrEmpty(cidade.Est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Est_UF");

            if (string.IsNullOrEmpty(cidade.Cid_CodIBGE))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Cid_CodIBGE");

            if (string.IsNullOrEmpty(cidade.Cid_Nome))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Cid_Nome");

            string sSql = $"spCidadesIncluir '{cidade.Est_UF}','{cidade.Cid_CodIBGE}','{cidade.Cid_Nome}'";

            BDSqlServer.BD.executaComando(sSql);
        }

        /// <summary>
        /// Altera os dados da cidade no banco de dados 
        /// </summary>
        /// <param name="cidade">Cidade a ser salva</param>
        public static void setAlterar(Cidade cidade)
        {
            if (string.IsNullOrEmpty(cidade.Est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Est_UF");

            if (string.IsNullOrEmpty(cidade.Cid_CodIBGE))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Cid_CodIBGE");

            if (string.IsNullOrEmpty(cidade.Cid_Nome))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Cid_Nome");

            string sSql = $"spCidadesAlterar '{cidade.Est_UF}','{cidade.Cid_CodIBGE}','{cidade.Cid_Nome}'";

            BDSqlServer.BD.executaComando(sSql);
        }

        /// <summary>
        /// Exclui a Cidade
        /// </summary>
        /// <param name="cidade">Cidade a ser exluída</param>
        public static void setExcluir(Cidade cidade)
        {
            if (string.IsNullOrEmpty(cidade.Cid_CodIBGE))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Cid_CodIBGE");

            string sSql = $"spCidadesExcluir '{cidade.Cid_CodIBGE}'";

            BD.executaComando(sSql);
        }

        /// <summary>
        /// Recupera lista de Cidades
        /// </summary>
        /// <param name="where">Critério de pesquisa a ser aplicado na clausula where</param>
        /// <returns>Lista tipara de Cidades</returns>
        public static List<Cidade> getCidades(string where = "")
        {
            List<Cidade> listaCidades = new List<Cidade>();

            string sSql = $"select * from vwCidades {(string.IsNullOrEmpty(where) ? "" : $"where {where}")}";

            using (DataTable dt = BD.getDataTable(sSql))
            {
                if (dt.Rows.Count == 0)
                {
                    listaCidades.Add(new Cidade());
                }
                else
                    foreach (DataRow dr in dt.Rows)
                    {
                        listaCidades.Add(
                            new Cidade
                            {
                                Est_UF = dr["Est_UF"].ToString(),
                                Cid_CodIBGE = dr["Cid_CodIBGE"].ToString(),
                                Cid_Nome = dr["Cid_Nome"].ToString()
                            }
                        );
                    }
            }
            return listaCidades;
        }

        /// <summary>
        /// Recupera uma cidade específica 
        /// </summary>
        /// <param name="cid_CodIBGE">código IBGE da cidade a ser recuperada</param>
        /// <returns>Estado recuperado ou NULL se não localizar a UF</returns>
        public static Cidade getCidade(string cid_CodIBGE)
        {
            if (string.IsNullOrEmpty(cid_CodIBGE))
                throw new System.ArgumentException("Parametro não poder fica em branco", "cid_CodIBGE");


            string sSql = $"select * from vwCidades where Est_UF = '{cid_CodIBGE}'";

            using (DataTable dt = BD.getDataTable(sSql))
            {
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return new Cidade
                    {
                        Est_UF = dt.Rows[0]["Est_UF"].ToString(),
                        Cid_CodIBGE = dt.Rows[0]["Cid_CodIBGE"].ToString(),
                        Cid_Nome = dt.Rows[0]["Cid_Nome"].ToString()
                    };
                }
            }
        }
    }
}