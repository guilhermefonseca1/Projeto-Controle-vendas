using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_vendas.br.com.projeto.model
{
    //Essa classe foi criada apenas para armazenar alguns métodos mais utilizados no dia-a-dia
    public class Helpers
    {
        //1 Passo - Criar um método para limpar a tela e passar qual é a tela que será limpa
        //neste caso ela é um objeto chamado de "tela" presente na classe "Form"
        public void LimparTela(Form tela)
        { 
            //2 Passo - Definir para que o C# percorra todos os controles/inputs da minha tela
            //e num para cada controle que ele percorre, chamará um ctrPai
            foreach (Control ctrPai in tela.Controls)
            {
                foreach(Control ctr1 in ctrPai.Controls)
                {
                    //3 Passo - Verificar se existe um TabPage no ctrPai
                    if (ctr1 is TabPage) 
                    { 
                    foreach (Control ctr2 in ctr1.Controls)
                    //4 Passo - Se sim, verificar quais são TextBox
                        {
                            if(ctr2 is TextBox) 
                            {
                                //5 Passo - Limpe o campo do TextBox
                                (ctr2 as TextBox).Text = string.Empty;
                            }
                            //6 Passo - Se encontrar um MaskedTextBox

                            if (ctr2 is MaskedTextBox)
                            {
                                //7 Passo - Limpe o campo do MaskedTextBox
                                (ctr2 as MaskedTextBox).Text = string.Empty;
                            }
                            //7 Passo - Se encontrar um Combobox
                            if (ctr2 is ComboBox)
                            {
                                //5 Passo - Limpe o campo do MaskedTextBox
                                (ctr2 as ComboBox).Text = string.Empty;
                            }

                        }
                    }
                }
            }
        }
    }
}
