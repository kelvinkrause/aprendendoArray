using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoInicial = 5) 
        // Se não passado parâmetro no construror, será usado o valor 5 para atribuir a inicialização do array
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente conta)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            _itens[_proximaPosicao] = conta;
            _proximaPosicao++;
        }

        public void Remover(ContaCorrente conta)
        {
            int indiceItem = 0;
            
            //Procura o indice da Conta na lista.
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] == conta)
                {
                    indiceItem = i;
                    break;
                }
            }

            //Console.WriteLine("\nindice item: " + indiceItem);
            //Console.WriteLine("proxima posicao: " + _proximaPosicao + "\n");

            //Através do indice da conta a ser removido, começa a subescrever com as contas subsequentes.
            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
        }


        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando a capacidade da lista");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for(int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i]; 
            }

            _itens = novoArray;
        }

        public ContaCorrente ContaComMaiorSaldo()
        {
            ContaCorrente contaComMaiorSaldo = null!;
            int maiorValor = 0;

            for(int i = 0; i < _itens.Length; i++)
            {
                if(_itens[i] != null)
                {
                    if(maiorValor < _itens[i].Saldo)
                    {
                        contaComMaiorSaldo = _itens[i];
                        maiorValor = (int) contaComMaiorSaldo.Saldo;
                        Console.WriteLine("->" + maiorValor);
                    }
                }
            }

            return contaComMaiorSaldo!;
        }

        public void ExibirContasCorrentes()
        {
            for(int i = 0; i < _itens.Length; i++)
            {
                if(_itens[i] != null)
                {
                    Console.WriteLine($"Conta: {_itens[i].Conta}");                    
                }
            }
        }

    }
}