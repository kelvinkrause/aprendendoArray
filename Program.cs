using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

        //Console.WriteLine(Guid.NewGuid().ToString()); //7287179b-039f-408d-b121-93de049d7094

        new ByteBankAtendimento();

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
        List<ContaCorrente> _listaDeContas = new List<ContaCorrente>() 
        {
        new ContaCorrente(888888, "KK1") {Saldo = 10000, Titular = new Cliente() {Nome = "Kelvin Renan Krause", Cpf = "203010"}},
        new ContaCorrente(888888, "GG2") {Saldo = 10000, Titular = new Cliente() {Nome = "Giovana Born de Aguiar", Cpf = "102030"}},
        new ContaCorrente(000000, "PP3") {Saldo = 50000, Titular = new Cliente() {Nome = "Particular", Cpf = "000000"}}
        };

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

