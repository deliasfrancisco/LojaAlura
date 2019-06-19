
namespace ByteBank.SistemaAgencia
{ 
    static void Main(string[] args)
    { 

        ContaCorrente[] contas = new ContaCorrente[]
            { 
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 4456668),
                new ContaCorrente(874, 7781438),
            };

        for (int indice = 0; indice < Contas.Length; indice++)
        {
            ContaCorrente contaAtual = contas[indice];
            Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
        }

        Console.ReadLine();
    }



    public class ListaDeContaCorrente
    { 

        private ContaCorrente[] _itens; //craição de uma vetor privado chamado _itens e do tipo de COntasCorrente
        private int _proximaPosicao;

        public ListaDeContaCorrente()// criação do construtor (ctor - atalho para a criação)
        {
            _itens = new ContaCorrente[5]; //informando o tamanho do vetor
            _proximaPosicao = 0; //variavel criada para ser incrementada a cada campo preenchido do vetor
        }
        public void Adicionar(ContaCorrente item) //metodo criado para adicinar contas no vetor
        {
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item; //vetor recebendo o item passado por parametro
            _proximaPosicao++; //incremento da proxima posição
        } 
    }
	
	private void VerificaCapacidade(int tamanhoNecessario){
		if (_itens.Length >= tamanhoNecessario){ //quando a leitura supera o tamnho do vetor é necessario a craição de um vetor com mais posições para que ele receba os itens do vetor antigo
			return;
		}
		
		for (int i =0 ; i < _itens.Length(); i++){
			array[i] = _itens[i]
		}
		
		
		
		ContaCorrente[] array = int ContaCorrente[tamanhoNecessario];
	}
}

{
    public void Sacar(double valor)...

    public void Depositar(double valor)...

    public void Transferir(double valor, ContaCorrente contaDestino)...

    public override bool Equals(object obj)
    { 


        return base.Equals(obj);
    } 
} 

public void Remover(ContaCorrente item)
{ 
    int indiceItem = -1;

    for(int i = 0; i < _proximaPosicao; i++)
    { 
        ContaCorrente itemAtual = _itens[i];

        if (itemAtual.Equals(item))
        { 

        } 
    } 
} 

public [__] this[__]
{
    get
    {
        ContaCorrente[] resultado = new ContaCorrente[__];
        for (int i = 0; i < indices.Length; i++)
        {
            int indiceDaLista = indices[i];
            resultado[i] = GetItemNoIndice(indiceDaLista);
        }
        return resultado;
    }
}

ContaCorrente[], [params int[] indices] e [indices.Length].

 
Correta! Isto é possível apenas com o uso de argumentos params no indexador.


















