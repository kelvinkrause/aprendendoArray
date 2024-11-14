using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento;
public class ByteBankAtendimento
{
    
    static List<ContaCorrente> _listaDeContas = null!;

    public ByteBankAtendimento()
    {
        _listaDeContas = new List<ContaCorrente>() 
        {
        new ContaCorrente(888888, "KK1") {Saldo = 10000, Titular = new Cliente() {Nome = "Kelvin Renan Krause", Cpf = "203010"}},
        new ContaCorrente(888888, "GG2") {Saldo = 10000, Titular = new Cliente() {Nome = "Giovana Born de Aguiar", Cpf = "102030"}},
        new ContaCorrente(000000, "PP3") {Saldo = 50000, Titular = new Cliente() {Nome = "Particular", Cpf = "000000"}}
        };

        List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>() 
        {
        new ContaCorrente(888888, "MM4") {Saldo = 11000},
        new ContaCorrente(202020, "AA5") {Saldo = 12000},
        new ContaCorrente(000000, "DD6") {Saldo = 55000}
        };

        AtendimentoCliente();
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
                    case '5':
                        PesquisarContas();
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

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine()!);

        ContaCorrente conta = new ContaCorrente(numero_agencia: numeroAgencia);
        
        Console.Write($"Numero Conta [Nova]: {conta.Conta}");

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

    void PesquisarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     PESQUISAR CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA, (2) CPF TITULAR ou (3) NUMERO AGÊNCIA? ");

        switch(int.Parse(Console.ReadLine()!))
        {
            case 1:
                Console.Write("Informe o Numero da Conta: ");
                ContaCorrente consultaNumeroConta = ConsultaPorNumeroConta(Console.ReadLine()!);
                if (consultaNumeroConta == null) 
                {
                    Console.WriteLine("Conta não encontrada a partir do Numero da Conta.");
                    Console.ReadKey(true);
                    return;
                }
                Console.WriteLine($"\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(consultaNumeroConta);
                Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
                break;
            case 2:
                Console.Write("Informe o Numero do CPF do Titular: ");
                ContaCorrente consultaCPFContaTitular = ConsultaPorCPFTitular(Console.ReadLine()!);
                if (consultaCPFContaTitular == null) 
                {
                    Console.WriteLine("Conta não encontrada a partir do CPF.");
                    Console.ReadKey(true);
                    return;
                }
                Console.WriteLine($"\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(consultaCPFContaTitular);
                Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
                break;
            case 3:
                Console.Write("Infome o Numero da Agência: ");
                var _listaContasPorNumAgencia = ConsultaPorNumeroAgencia(int.Parse(Console.ReadLine()!));
                foreach(ContaCorrente conta in _listaContasPorNumAgencia) 
                {
                    Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine(conta);
                    Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opcao não implementada.");
                break;
        }

    }

    ContaCorrente ConsultaPorNumeroConta(string numeroConta)
    {
        //foreach(ContaCorrente conta in _listaDeContas)
        //{
        //    if(conta.Conta.Equals(numeroConta)) return conta;
        //}
        //return null;

        return _listaDeContas
                    .Where(conta => conta.Conta.Equals(numeroConta))
                    .FirstOrDefault()!;
    }
    
    ContaCorrente ConsultaPorCPFTitular(string cpfTitular)
    {
        //foreach(ContaCorrente conta in _listaDeContas)
        //{
        //    if(conta.Titular.Cpf.Equals(cpfTitual)) return conta;
        //}
        //return null;

        return _listaDeContas
                    .Where(conta => conta.Titular.Cpf.Equals(cpfTitular))
                    .FirstOrDefault()!;
    }

    List<ContaCorrente> ConsultaPorNumeroAgencia(int numeroAgencia)
    {
        return _listaDeContas = (from conta in _listaDeContas
                                where conta.Numero_agencia.Equals(numeroAgencia)
                                select conta).ToList();
    }

    void SairDoSistema()
    {
        Console.Clear();
        Console.WriteLine("Saindo do sistema ByteBank");
        Thread.Sleep(800);
        Console.Clear();
    }


}
