using Projeto_Controle_vendas.br.com.projeto.dao;
using Projeto_Controle_vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Projeto_Controle_vendas.br.com.projeto.view
{
    public partial class Frmclientes : Form
    {
        public Frmclientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            //1 Passo - Receber os dados que estão dentro do objeto model de Cliente
            Cliente obj = new Cliente();
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereço.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomplemento.Text;
            obj.bairro = txtbairro.Text;    
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;

            //2 passo - Criar um objeto por meio da classe ClienteDAO e chamar o metodo cadastrarCliente
            //para inserir as informações inseridas na view e armazenadas na model
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);
        }
    }
}
