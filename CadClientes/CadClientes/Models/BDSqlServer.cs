using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;

namespace BDSqlServer
{
    public class ClBDSqlServer
    {
        public static string sConexao = "";

        public static bool testaConexao()
        {
            SqlConnection myConexao = new SqlConnection();
            myConexao.ConnectionString = sConexao;
            myConexao.Open();
            if (myConexao.State == ConnectionState.Open)
            myConexao.Close();
            myConexao = null;
            return true;
        }

        public static DataSet getDataSet(String comandoSql, String nomeTabela)
        {
            SqlConnection myConexao = null;
            DataSet dsResultado;
            dsResultado = new DataSet(nomeTabela);
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();
            SqlDataAdapter daAdapter = new SqlDataAdapter(comandoSql, myConexao);
            daAdapter.Fill(dsResultado, nomeTabela);
            myConexao.Close();
            myConexao.Dispose();
            myConexao = null;
            return dsResultado;
        }

        public static string getCampoString(String comandoSql)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            SqlDataAdapter daAdapter = new SqlDataAdapter(comandoSql, myConexao);
            daAdapter.SelectCommand.CommandTimeout = 10800;
            DataTable table = new DataTable();
            daAdapter.Fill(table);
            DataRow[] rows = table.Select();
            string retorno = "";
            if (rows.Length != 0)
                retorno = rows[0][0].ToString();
            if (myConexao != null)
            {
                myConexao.Close();
                myConexao = null;
            }
            return retorno;

        }

        public static int getCampoInt(String comandoSql)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            SqlDataAdapter daAdapter = new SqlDataAdapter(comandoSql, myConexao);
            daAdapter.SelectCommand.CommandTimeout = 10800;
            DataTable table =  getDataTable(comandoSql);

            int retorno = 0;
            if (table.Rows.Count > 0)
                retorno =  Convert.ToInt32(table.Rows[0][0]);

            if (myConexao != null)
            {
                myConexao.Close();
                myConexao = null;
            }

            return retorno;
        }

        public static double getCampoDouble(String comandoSql)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            SqlDataAdapter daAdapter = new SqlDataAdapter(comandoSql, myConexao);
            daAdapter.SelectCommand.CommandTimeout = 10800;
            DataTable table = new DataTable();
            daAdapter.Fill(table);
            DataRow[] rows = table.Select();

            double retorno = 0;
            if (rows.Length != 0)
                retorno = Convert.ToDouble(rows[0][0]);

            if (myConexao != null)
            {
                myConexao.Close();
                myConexao = null;
            }
            return retorno;
        }

        public static DateTime getDateTimeBD()
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            SqlDataAdapter daAdapter = new SqlDataAdapter("select GETDATE()", myConexao);
            daAdapter.SelectCommand.CommandTimeout = 10800;
            DataTable table = new DataTable();
            daAdapter.Fill(table);
            DataRow[] rows = table.Select();

            DateTime retorno = DateTime.Now;
            retorno = Convert.ToDateTime(rows[0][0]);
            myConexao.Close();
            myConexao = null;
            return retorno;
        }

        public static int executaComandoInt(String sql)
        {
            SqlConnection myConexao = null;
            SqlCommand myComando = new SqlCommand();
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            int retorno = 0;

            myComando.Connection = myConexao;
            myComando.CommandType = CommandType.Text;
            myComando.CommandText = sql;
            myComando.CommandTimeout = 10800;
            myComando.ExecuteNonQuery();
            myConexao.Close();
            myConexao = null;
            myComando = null;

            return retorno;
        }

        public static int executaInsertRecuperaId(String sql)
        {
            SqlConnection myConexao = null;
            SqlCommand myComando = new SqlCommand();
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            myComando.Connection = myConexao;
            myComando.CommandType = CommandType.Text;
            myComando.CommandText = sql + " select SCOPE_IDENTITY()";
            myComando.CommandTimeout = 10800;

            int retorno = Convert.ToInt32(myComando.ExecuteScalar());
            myConexao.Close();
            myConexao = null;
            myComando = null;

            return retorno;
        }

        public static int executaInsertRecuperaId(String sql, SqlConnection pConexao, SqlTransaction pTrans)
        {
            SqlCommand myComando = pConexao.CreateCommand();
            myComando.CommandType = CommandType.Text;
            myComando.CommandText = sql + " select SCOPE_IDENTITY()";
            myComando.CommandTimeout = 10800;
            myComando.Transaction = pTrans;
            int retorno = Convert.ToInt32(myComando.ExecuteScalar());
            myComando = null;
            return retorno;
        }

        public static int executaInsertRecuperaId(String sql, SqlConnection myConexao)
        {
            int retorno = 0;
            try
            {
                SqlCommand myComando = new SqlCommand();
                myComando.Connection = myConexao;
                myComando.CommandType = CommandType.Text;
                myComando.CommandText = sql + Environment.NewLine +" select SCOPE_IDENTITY()";
                myComando.CommandTimeout = 10800;

                retorno = Convert.ToInt32(myComando.ExecuteScalar());
                myComando = null;

            }
            catch (Exception)
            {
                retorno = executaInsertRecuperaId(sql);
            }

            return retorno;
        }

        public static int executaComando(string sql)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();
            SqlCommand myComando = new SqlCommand();
            myComando.Connection = myConexao;
            myComando.CommandType = CommandType.Text;
            myComando.CommandText = sql;
            myComando.CommandTimeout = 10800;
            int QtdeLinhas = myComando.ExecuteNonQuery();
            myComando.Dispose();
            myConexao.Close();
            myConexao = null;
            myComando = null;
            return QtdeLinhas;
        }
        public static int executaComando(string sql, SqlTransaction pTrans)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();
            SqlCommand myComando = new SqlCommand();
            myComando.Connection = myConexao;
            myComando.CommandType = CommandType.Text;
            myComando.CommandText = sql;
            myComando.CommandTimeout = 10800;
            myComando.Transaction = pTrans;
            int QtdeLinhas = myComando.ExecuteNonQuery();
            myComando.Dispose();
            myConexao.Close();
            myConexao = null;
            myComando = null;
            return QtdeLinhas;
        }

        public static int executaComando(string sql, SqlConnection pConexao, SqlTransaction pTrans)
        {
            SqlCommand myComando = pConexao.CreateCommand();
            myComando.CommandType = CommandType.Text;
            myComando.CommandText = sql;
            myComando.CommandTimeout = 10800;
            myComando.Transaction = pTrans;
            int QtdeLinhas = myComando.ExecuteNonQuery();
            myComando.Dispose();
            myComando = null;
            return QtdeLinhas;
        }

        public static void executaComando(string sql, SqlConnection myConexao)
        {
            try
            {
                SqlCommand myComando = new SqlCommand();
                myComando.Connection = myConexao;
                myComando.CommandType = CommandType.Text;
                myComando.CommandText = sql;
                myComando.CommandTimeout = 10800;
                myComando.ExecuteNonQuery();
                myComando.Dispose();
                myComando = null;
            }
            catch (Exception)
            { 
                executaComando(sql); 
            }
        }

        public static DataTable getDataTable(String comandoSql, String nomeTabela)
        {
            DataTable retorno = new DataTable();
            SqlConnection myConexao = null;
            SqlDataAdapter daAdapter;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();
            daAdapter = new SqlDataAdapter(comandoSql, myConexao);
            daAdapter.SelectCommand.CommandTimeout = 10800;
            daAdapter.Fill(retorno);
            myConexao.Close();
            myConexao = null;
            return retorno;
        }

        public static DataTable getDataTable(String comandoSql)
        {
            SqlConnection myConexao = null;
            DataTable RetDT = new DataTable();
            SqlDataAdapter daAdapter;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();
            daAdapter = new SqlDataAdapter(comandoSql, myConexao);
            daAdapter.SelectCommand.CommandTimeout = 10800;
            daAdapter.Fill(RetDT);
            myConexao.Close();
            myConexao = null;
            return RetDT;
        }

        public static DataTable getDataTable(String comandoSql, SqlConnection myConexao)
        {
            DataTable RetDT = new DataTable();
            try
            {
                SqlDataAdapter daAdapter;
                daAdapter = new SqlDataAdapter(comandoSql, myConexao);
                daAdapter.SelectCommand.CommandTimeout = 10800;
                daAdapter.Fill(RetDT);
            }
            catch (Exception)
            {
                RetDT = getDataTable(comandoSql);
            }
            return RetDT;
        }

        public static DataRow getRegistro(String comandoSql)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            SqlDataAdapter daAdapter = new SqlDataAdapter(comandoSql, myConexao);
            daAdapter.SelectCommand.CommandTimeout = 10800;
            DataTable table = new DataTable();
            daAdapter.Fill(table);
            DataRow[] rows = table.Select();
            myConexao.Close();
            myConexao = null;

            if (rows.Length == 0)
                return null;
            else
                return rows[0];
        }

        public static SqlDataReader getDataReader(String comandoSql)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            SqlCommand myCommand = new SqlCommand(comandoSql, myConexao);
            myCommand.CommandTimeout = 10800;
            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return myReader;
        }

        public static int doExecutaSProcedure(SqlCommand myComando, String nomeSProcedure, Boolean querRetorno, string sConexao)
        {
            SqlConnection myConexao = null;
            myConexao = new SqlConnection(sConexao);
            myConexao.Open();

            int retorno = 0;

            myComando.Connection = myConexao;
            myComando.CommandType = CommandType.StoredProcedure;
            myComando.CommandText = nomeSProcedure;
            myComando.CommandTimeout = 10800;

            myComando.ExecuteNonQuery();
            if (querRetorno)
                retorno = Convert.ToInt32(myComando.Parameters[myComando.Parameters.Count - 1].Value);

            myConexao.Close();
            myConexao = null;

            return retorno;
        }

    
    }
}
