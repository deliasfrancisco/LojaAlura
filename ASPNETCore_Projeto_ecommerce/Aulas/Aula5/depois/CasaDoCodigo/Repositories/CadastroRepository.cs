using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Task<Cadastro> Update(int cadastroId, Cadastro novoCadastro); //esse metodo para atualização recebe dois parametros, o objeto cadastro e uma variavel para referencia do id
    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Cadastro> Update(int cadastroId, Cadastro novoCadastro) 
            {
            var cadastroDB = //variavel que vai receber o cadastro do banco de dados
                await dbSet.Where(c => c.Id == cadastroId) //filtrar o cadastro pelo id
                .SingleOrDefaultAsync();

            if (cadastroDB == null) //tratando se ele for nulo
            {
                throw new ArgumentNullException("cadastro"); //lançando uma exceção de argumento
            }

            cadastroDB.Update(novoCadastro); //atualizando o cadastro no banco com os novos dados
            await contexto.SaveChangesAsync(); //salvando mudanças
            return cadastroDB; //retornando o cadastro
        }
    }
}
