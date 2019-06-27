using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetodoExtensaoEClasseGenerica.Beans;

namespace MetodoExtensaoEClasseGenerica.Controllers
{
    public class ClienteController : Cliente
    {
        public ClienteController(int idade, string nome, string endereco) : base(idade, nome, endereco)
        {

        }

        Cliente cliente = new Cliente();

        public int SomaIdades(int idade)
        {
            this.cliente.idade = idade;
            idade += idade;
            return idade;
        }

        public double MediaIdade(int idade)
        {
            int media = 0;
            this.cliente.idade = idade;
            media += idade / 5;
            return media;
        }
    }
}
