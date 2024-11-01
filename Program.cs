using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

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
    
    
    }
}

