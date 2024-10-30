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


        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            System.Console.WriteLine("Aumentando a capacidade da lista");
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

    }
}