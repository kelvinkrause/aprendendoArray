using System.Collections;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;

internal class Program
{

    static List<ContaCorrente> _listaDeContas = null!;

    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

        _listaDeContas = new List<ContaCorrente>() 
        {
        new ContaCorrente(888888, "KK1") {Saldo = 10000},
        new ContaCorrente(202020, "GG2") {Saldo = 10000},
        new ContaCorrente(000000, "PP3") {Saldo = 50000}
        };

        List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>() 
        {
        new ContaCorrente(888888, "MM4") {Saldo = 11000},
        new ContaCorrente(202020, "AA5") {Saldo = 12000},
        new ContaCorrente(000000, "DD6") {Saldo = 55000}
        };

        new Program().AtendimentoCliente();

    }

    void AtendimentoCliente()
    {
        try
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

                try
                {
                    opcao = Console.ReadLine()![0];
                }
                catch (Exception excecao)
                {

                    throw new ByteBankException(excecao.Message);
                }

                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverConta();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '6':
                        SairDoSistema();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
        }
        catch (ByteBankException exececao)
        {
            Console.WriteLine($"{exececao.Message}");
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
            Console.WriteLine($"{conta.ToString()}\n");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");

        }
        Console.Write("Digite algo para retornar ao menu principal!");
        Console.ReadKey();

    }

    void RemoverConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      REMOVER CONTA      ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        System.Console.Write("Informe o Numero da Conta: ");
        string numeroConta = Console.ReadLine()!;

        ContaCorrente contaCorrente = null;

        foreach(ContaCorrente conta in _listaDeContas)
        {
            if(conta.Conta.Equals(numeroConta))
            {
                contaCorrente = conta;
                break;
            }
        }

        if(contaCorrente != null)
        {
            _listaDeContas.Remove(contaCorrente);
            Console.WriteLine("... Conta removida da lista! ...");
        }
        else
        {
            Console.WriteLine("... Conta para remoção não encontrada na lista ...");
        }
        
        Console.ReadKey();

    }

    void OrdenarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      ORDENAR CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        _listaDeContas.Sort();
        Console.WriteLine("... Lista de Contas Ordenadas ...");
        Console.ReadKey(true);

    }
    void SairDoSistema()
    {
        Console.Clear();
        Console.WriteLine("Saindo do sistema ByteBank");
        Thread.Sleep(800);
        Console.Clear();
    }

    void ManipulandoArray()
    {
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
    }

    void MinipulandoList()
    {
        //_listaDeContas.AddRange(_listaDeContas2);

        _listaDeContas.Reverse();

        _listaDeContas.ForEach(contas => Console.WriteLine(contas.Conta));
        var range = _listaDeContas.GetRange(0, 2);
        range.ToList().ForEach(conta => Console.WriteLine("-> " + conta.Conta));


        List<string> nomesDosEscolhidos = new List<string>()
        {
            "Bruce Wayne",
            "Carlos Vilagran",
            "Richard Grayson",
            "Bob Kane",
            "Will Farrel",
            "Lois Lane",
            "General Welling",
            "Perla Letícia",
            "Uxas",
            "Diana Prince",
            "Elisabeth Romanova",
            "Anakin Wayne"
        };

        System.Console.WriteLine(nomesDosEscolhidos.Contains("Anakin Wayne") ? "Contem" : "Não Contém");


    }

}

public class ClasseGenerica<ContaCorrente> 
{

    //ClasseGenerica<ContaCorrente>.Mensagem("Teste");

    public static void Mensagem(string mensagem)
    {
        System.Console.Write($"Essa é uma classe genérica: {mensagem}");
        Console.ReadKey();
    }
}

