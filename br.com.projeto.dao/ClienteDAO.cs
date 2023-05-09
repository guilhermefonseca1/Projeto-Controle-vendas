﻿using MySql.Data.MySqlClient;
using Projeto_Controle_vendas.br.com.projeto.conexao;
using Projeto_Controle_vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
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
        //Metodo CadastrarCliente
        public void cadastrarCliente(Cliente obj)
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
            }
            catch (Exception erro)
			{

                MessageBox.Show("Aconteceu o erro: " + erro);

            }
        }
    }
}
//Metodo AlterarCliente
//Metodo ExcluirCliente
//Metodo ListarCliente
//Metodo BuscarCliente


