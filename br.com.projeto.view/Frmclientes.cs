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
            dao.CadastrarCliente(obj);
            //3 Passo - Atualizar/Recarregar(DataGridView) a tabela de consulta removendo o elemento que foi excluído
            tabelacliente.DataSource = dao.ListarClientes();
        }

        private void Frmclientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelacliente.DataSource = dao.ListarClientes();
        }

        private void tabelacliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1 Passo - Pegar os dados do indivíduo clicando na linha da tabela consulta em que o objeto se encontra
            //2 Passo - Inserir os dados que foram selecionados no passo anterior e inseri-lós
            //nos inputs da form
            txtcodigo.Text = tabelacliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelacliente.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelacliente.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelacliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelacliente.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelacliente.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelacliente.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelacliente.CurrentRow.Cells[7].Value.ToString();
            txtendereço.Text = tabelacliente.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelacliente.CurrentRow.Cells[9].Value.ToString();
            txtcomplemento.Text = tabelacliente.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelacliente.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelacliente.CurrentRow.Cells[12].Value.ToString();
            cbuf.Text = tabelacliente.CurrentRow.Cells[13].Value.ToString();

            //1.1 Passo - Ao clicar em um contato, a aba será mudada automaticamente
            //tabClientes é o nome do painel em que estão inseridos os Dados Pessoais e Consulta
            //tabPage1 é o nome da tabela Dados Pessoais
            tabClientes.SelectedTab = tabPage1;
            
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //1 Passo - Criar um objeto para armazenar o elemento que será excluído
            Cliente obj = new Cliente();
            //2 Passo - Pegar o código/id do elemento que será excluído
            obj.codigo = int.Parse(txtcodigo.Text);
            //3 Passo - Inserir o elemento dentro de um novo objeto e excluí-lo
            ClienteDAO dao = new ClienteDAO();
            dao.ExcluirCliente(obj);
            //4 Passo - Atualizar/Recarregar(DataGridView) a tabela de consulta removendo o elemento que foi excluído
            tabelacliente.DataSource = dao.ListarClientes();
        }

        private void btneditar_Click(object sender, EventArgs e)
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
            obj.codigo = int.Parse(txtcodigo.Text);

            //2 passo - Criar um objeto por meio da classe ClienteDAO e chamar o metodo AlterarCliente
            //para inserir as informações inseridas na view e armazenadas na model
            ClienteDAO dao = new ClienteDAO();
            dao.AlterarClientes(obj);
            //4 Passo - Atualizar/Recarregar(DataGridView) a tabela de consulta atualizando o elemento que foi alterado
            tabelacliente.DataSource = dao.ListarClientes();
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            //1 Passo - Pegar o nome digitado no campo pesquisar e armazenar em uma variável
            //chamada nome
            string nome = txtpesquisa.Text;
            //2 Passo - Buscar o método BuscarClientePorNome que está dentro da classe ClienteDAO
            ClienteDAO dao = new ClienteDAO();
            //3 Passo - Os dados que serão carregados no DataGridView são originários do resultado
            //do dao(BuscarClientePorNome) sendo passado a variável nome como parâmetro
            tabelacliente.DataSource = dao.BuscarClientePorNome(nome);
        }
    }
}
