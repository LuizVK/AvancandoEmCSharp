using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays


//TestaArrayInt();

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"índice [{i}] = {idades[i]}");

        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"A média de idades é {media}");
}

// Outra aula 

//TestaBuscarPalavra();

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine()!;
    }

    Console.Write("Digite palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
    }
}

// Outra aula

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//TestaMediana(amostra);

//[5.9] [1.8] [7.1] [10] [6.9]

void TestaMediana(Array array)
{
    if (array == null || array.Length == 0)
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    //[1.8] [5.9] [6.9] [7.1] [10]


    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana = {mediana}.");
}

// Outra aula

//TestaArrayDeContasCorrentes();

void TestaArrayDeContasCorrentes()
{
    ContaCorrente[] listaDeContas = new ContaCorrente[]
    {
        new ContaCorrente(874, "59856656-A"),
        new ContaCorrente(874, "98856326-B"),
        new ContaCorrente(874, "16522354-C")
    };

    for (int i = 0; i < listaDeContas.Length; i++)
    {
        ContaCorrente contaAtual = listaDeContas[i];

        Console.WriteLine($"Índice {i} - Conta: {contaAtual.Conta}");
    }
}

//TestaArrayDeContasCorrentes2();

void TestaArrayDeContasCorrentes2()
{
    ListaContasCorrentes listaDeContas = new ListaContasCorrentes();

    listaDeContas.Adicionar(new ContaCorrente(874, "59856656-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "98856326-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "16522354-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "16522354-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "16522354-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "16522354-C"));

    var contaDoLuiz = new ContaCorrente(963, "123456_X");
    listaDeContas.Adicionar(contaDoLuiz);
    //listaDeContas.ExibirLista();
    //Console.WriteLine("================");
    //listaDeContas.Remover(contaDoLuiz);
    //listaDeContas.ExibirLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

#endregion


ByteBankAtendimento atendimento = new ByteBankAtendimento();
atendimento.AtendimentoCliente();

