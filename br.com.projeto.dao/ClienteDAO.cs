using MySql.Data.MySqlClient;
using Projeto_Controle_vendas.br.com.projeto.conexao;
using Projeto_Controle_vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_vendas.br.com.projeto.dao
{
    public class ClienteDAO
    {
        private MySqlConnection conexao;
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getConnection();
        }




        #region CadastrarCliente
        //Metodo CadastrarCliente
        public void CadastrarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o cmd sql - insert into (Valores que eu quero cadastrar)
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                                value (@nome,@rg,@cpf,@email,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado) ";
                //Na linha de cima temos as variáveis/parametro(são as Parameters) que vão receber os valores que eu quero inserir

                //2 passo - Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente cadastrado com sucesso");
                //4 passo -Fechar a conexao com o banco 
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);

            }
        }
        #endregion

        //DataGridView = Exibe os dados
        //→ DataTable recebe os dados de uma lista
        //→ MySqlDataAdpter é um adaptador que pega os dados retornados pelo comando Select, usado em uma pesquiso ao banco de dados, e Preenche o DataTable
        //* O MySqlDataAdpter  faz a ligação entre o banco de dados e o DataTable

        #region AlterarClientes
        //Metodo AlterarCliente
        public void AlterarClientes(Cliente obj)
        {
            try
            {
                //1 passo - definir o cmd sql - update nome_da_tabela set(Valores que eu quero editar)
                //Ao editar/atualizar um elemento, é preciso fornecer o id desse elemento também
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                              endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                              where id=@id";
                //Na linha de cima temos as variáveis/parametro(são as Parameters) que vão receber os valores que eu quero inserir

                //2 passo - Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);


                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente editado com sucesso");
                //4 passo -Fechar a conexao com o banco 
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);

            }
        }
        #endregion

        #region ExcluirCliente
        //Metodo ExcluirCliente
        public void ExcluirCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o id do elemento que eu quero excluir
                string sql = @"delete from tb_clientes where id=@id";
                //Na linha de cima temos as variáveis/parametro(são as Parameters) que vão receber os valores que eu quero inserir

                //2 passo - Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente excluído com sucesso");
                //4 passo - Fechar a conexão com o banco de dados
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);

            }
        }
        #endregion

        #region ListarClientes
        //Metodo listarClientes
        public DataTable ListarClientes()
        {
            try
            {
                //1 passo - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "SELECT * FROM bdvendas.tb_clientes";

                //2 passo - Organizar o sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //4 passo - Criar o MySQLDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //5 passo - Fechar a conexao
                conexao.Close();
                return tabelacliente;


            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        //Metodo AlterarCliente
        //Metodo ExcluirCliente
        //Metodo BuscarCliente


        #endregion ListarClientes


        #region BuscarCliente
        //Metodo BuscarCliente
        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "SELECT * FROM bdvendas.tb_clientes where nome = @nome";

                //2 passo - Organizar o sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //4 passo - Criar o MySQLDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //5 passo - Fechar a conexao
                conexao.Close();
                return tabelacliente;


            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }
        #endregion


        #region ListarClientePorNome
        //Metodo ListarCliente
        public DataTable ListarClientePorNome(string nome)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "SELECT * FROM bdvendas.tb_clientes where nome like @nome";

                //2 passo - Organizar o sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //4 passo - Criar o MySQLDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //5 passo - Fechar a conexao
                conexao.Close();
                return tabelacliente;


            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }
        #endregion

    }
}

//Metodo ExcluirCliente


