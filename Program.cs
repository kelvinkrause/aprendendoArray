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
        cliente.Nome = "";

        listaDeContas.Adicionar(kelvin);
        listaDeContas.Adicionar(giovana);
        listaDeContas.Adicionar(particular);

        //listaDeContas.Adicionar(new ContaCorrente(555, "555555-PT"));
        //listaDeContas.Adicionar(new ContaCorrente(555, "555555-PT"));
        //listaDeContas.Adicionar(new ContaCorrente(555, "555555-PT"));

        ContaCorrente conta = listaDeContas.ContaComMaiorSaldo();

        Console.WriteLine(conta.ToString());  
    
    
    }
}

