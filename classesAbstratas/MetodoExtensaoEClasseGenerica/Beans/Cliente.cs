using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoExtensaoEClasseGenerica.Beans
{
    public class Cliente
    {
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public int idade { get; set; }


        public Cliente(int idade = 0, string nome = "", string endereco = "")
        {
            this.idade = idade;
            this.Nome = nome;
            this.Endereco = endereco;
        }

        
    }


}
