using System.Collections;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

internal class Program
{

    ArrayList _listaDeContas = new ArrayList();

    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

        new Program().AtendimentoCliente();


        #region Exemplos Array em C#
        ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();

        ContaCorrente kelvin = new ContaCorrente(777, "888888-KK");
        kelvin.Saldo = 8000;
        ContaCorrente giovana = new ContaCorrente(444, "202020-GG");
        giovana.Saldo = 10000;
        ContaCorrente particular = new ContaCorrente(555, "555555-PT");
        particular.Saldo = 20000;
        
        Cliente cliente = new Cliente();
        particular.Titular = cliente;

        particular.Titular.Nome = "Particular";

        listaDeContas.Adicionar(kelvin);
        listaDeContas.Adicionar(giovana);
        listaDeContas.Adicionar(particular);
        listaDeContas.Adicionar(new ContaCorrente(111, "999999-MM"));
        listaDeContas.Adicionar(new ContaCorrente(222, "222222-AA"));

        //listaDeContas.Adicionar(new ContaCorrente(555, "555555-PT"));
        //listaDeContas.Adicionar(new ContaCorrente(555, "555555-PT"));
        //listaDeContas.Adicionar(new ContaCorrente(555, "555555-PT"));

        //ContaCorrente conta = listaDeContas.ContaComMaiorSaldo();
        //Console.WriteLine(conta.ToString());  

        System.Console.WriteLine($"\nLista de Contas Correntes \n");
        listaDeContas.ExibirContasCorrentes();

        listaDeContas.Remover(kelvin);

        System.Console.WriteLine($"\nLista de Contas Correntes com a conta kelvin excluida\n");
        listaDeContas.ExibirContasCorrentes();

        Console.WriteLine();

        ContaCorrente contaAlguma = listaDeContas.RetornaContaIndice(1);
        Console.WriteLine(contaAlguma.Conta);

        System.Console.WriteLine();

        Console.WriteLine(listaDeContas[1].Conta);

        #endregion
    
    
    }

    void AtendimentoCliente()
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Digite a opção desejada: ");

            opcao = Console.ReadLine()[0];

            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
    }

    void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n=== Informe dados da conta ===");

        Console.Write("Número da Conta: ");
        string numeroConta = Console.ReadLine()!;

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine()!);

        ContaCorrente conta = new ContaCorrente(numero_agencia: numeroAgencia, conta: numeroConta);

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine()!);

        Console.Write("Informe o nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine()!;

        Console.Write("Informe CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine()!;   

        Console.Write("Informe Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine()!;
        
        _listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();

    }

    void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===    LISTA DE CONTAS      ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        if(_listaDeContas.Count <= 0)
        {
            Console.WriteLine("... Não há contas a serem listadas! ...");
            Console.ReadKey();
            return;
        }

        foreach(ContaCorrente conta in _listaDeContas)
        {
            Console.WriteLine($"{conta}\n");

        }

    }

}

