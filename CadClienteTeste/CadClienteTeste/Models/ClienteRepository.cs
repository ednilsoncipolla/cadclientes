using BDSqlServer;
using System;
using System.Collections.Generic;
using System.Data;

namespace CadClienteTeste.Models
{
    /// <summary>
    /// Repositorio de acesso a tabela de Clientes
    /// </summary>
    public static class ClienteRepository
    {
        /// <summary>
        /// Inclui um novo Cliente no banco de dados
        /// </summary>
        /// <param name="cliente">Cliente a ser inserido</param>
        public static void setIncluir(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "UF");

            if (string.IsNullOrEmpty(cliente.Cid_CodIBGE))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Cid_CodIBGE");

            if (string.IsNullOrEmpty(cliente.Cli_Nome))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Cid_CodIBGE");

            string sSql = $"spClientesIncluir '{cliente.Est_UF}' " +
                $",'{cliente.Cid_CodIBGE}'" +
                $",'{cliente.Cli_Id}'" +
                $",'{cliente.Cli_Nome}'" +
                $",'{cliente.Cli_Bairro}'" +
                $",'{cliente.Cli_EndEndereço}'" +
                $",'{cliente.Cli_EndNumero}'" +
                $",'{cliente.Cli_EndComplemento}'" +
                $",'{cliente.Cli_Email}'" +
                $",'{cliente.Cli_TelResidencial}'" +
                $",'{cliente.Cli_TelCelular}'";

            BDSqlServer.BD.executaComando(sSql);
        }

        /// <summary>
        /// Altera os dados do Cliente 
        /// </summary>
        /// <param name="cliente">Cliente a ser salvo</param>
        public static void setAlterar(Cliente cliente)
        {
            if (cliente.Cli_Id == 0)
                throw new System.ArgumentException("Parametro precisa ser maior que zero!", "Cli_Id");

            string sSql = $"spClientesAlterar '{cliente.Est_UF}' " +
                $",'{cliente.Cid_CodIBGE}'" +
                $",'{cliente.Cli_Id}'" +
                $",'{cliente.Cli_Nome}'" +
                $",'{cliente.Cli_Bairro}'" +
                $",'{cliente.Cli_EndEndereço}'" +
                $",'{cliente.Cli_EndNumero}'" +
                $",'{cliente.Cli_EndComplemento}'" +
                $",'{cliente.Cli_Email}'" +
                $",'{cliente.Cli_TelResidencial}'" +
                $",'{cliente.Cli_TelCelular}'";

            BDSqlServer.BD.executaComando(sSql);
        }

        /// <summary>
        /// Exclui o Cliente
        /// </summary>
        /// <param name="cliente">Cliente a ser exluído</param>
        public static void setExcluir(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Est_UF))
                throw new System.ArgumentException("Parametro não poder fica em branco", "UF");

            string sSql = $"spClientesExcluir '{cliente.Cli_Id}'";

            BD.executaComando(sSql);
        }

        /// <summary>
        /// Recupera lista de Clientes
        /// </summary>
        /// <param name="where">Critério de pesquisa a ser aplicado na clausula where</param>
        /// <returns>Lista tipada de Clientes</returns>
        public static List<Cliente> getClientes(string where = "")
        {
            List<Cliente> listaClientes = new List<Cliente>();

            string sSql = $"select * from vwClientes {(string.IsNullOrEmpty(where) ? "" : $"where {where}")}";

            using (DataTable dt = BD.getDataTable(sSql))
            {
                if (dt.Rows.Count == 0)
                {
                    listaClientes.Add(new Cliente());
                }
                else
                    foreach (DataRow dr in dt.Rows)
                    {
                        listaClientes.Add(
                            new Cliente
                            {
                                Est_UF = dr["Est_UF"].ToString(),
                                Cid_CodIBGE = dr["Cid_CodIBGE"].ToString(),
                                Cli_Id = Convert.ToInt32(dr["Cli_Id"]),
                                Cli_Nome = dr["Cli_Nome"].ToString(),
                                Cli_Bairro = dr["Cli_Bairro"].ToString(),
                                Cli_EndEndereço = dr["Cli_EndEndereço"].ToString(),
                                Cli_EndNumero = Convert.ToInt32(dr["Cli_EndNumero"]),
                                Cli_EndComplemento = dr["Cli_EndComplemento"].ToString(),
                                Cli_Email = dr["Cli_Email"].ToString(),
                                Cli_TelResidencial = dr["Cli_TelResidencial"].ToString(),
                                Cli_TelCelular = dr["Cli_TelCelular"].ToString()
                            }
                        );
                    }
            }
            return listaClientes;
        }

        /// <summary>
        /// Recupera um estado 
        /// </summary>
        /// <param name="Cli_Id">Id de identificação do cliente</param>
        /// <returns>Estado recuperado ou NULL se não localizar o cliente</returns>
        public static Cliente getCliente(string Cli_Id)
        {
            if (string.IsNullOrEmpty(Cli_Id))
                throw new System.ArgumentException("Parametro não poder fica em branco", "Est_UF");


            string sSql = $"select * from vwClientes where Cli_Id = '{Cli_Id}'";

            using (DataTable dt = BD.getDataTable(sSql))
            {
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return new Cliente
                    {
                        Est_UF = dt.Rows[0]["Est_UF"].ToString(),
                        Cid_CodIBGE = dt.Rows[0]["Cid_CodIBGE"].ToString(),
                        Cli_Id = Convert.ToInt32(dt.Rows[0]["Cli_Id"]),
                        Cli_Nome = dt.Rows[0]["Cli_Nome"].ToString(),
                        Cli_Bairro = dt.Rows[0]["Cli_Bairro"].ToString(),
                        Cli_EndEndereço = dt.Rows[0]["Cli_EndEndereço"].ToString(),
                        Cli_EndNumero = Convert.ToInt32(dt.Rows[0]["Cli_EndNumero"]),
                        Cli_EndComplemento = dt.Rows[0]["Cli_EndComplemento"].ToString(),
                        Cli_Email = dt.Rows[0]["Cli_Email"].ToString(),
                        Cli_TelResidencial = dt.Rows[0]["Cli_TelResidencial"].ToString(),
                        Cli_TelCelular = dt.Rows[0]["Cli_TelCelular"].ToString()
                    };
                }
            }
        }
    }
}