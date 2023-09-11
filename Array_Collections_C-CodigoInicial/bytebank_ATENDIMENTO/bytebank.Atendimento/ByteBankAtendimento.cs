using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    #nullable disable
    internal class ByteBankAtendimento
    {

        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(95, "123456-X") { Saldo = 100, Titular = new Cliente{ Cpf = "11111", Nome = "Henrique" }},
            new ContaCorrente(95, "951258-X") { Saldo = 200, Titular = new Cliente{ Cpf = "22222", Nome = "Pedro" }},
            new ContaCorrente(94, "987321-W") { Saldo = 60, Titular = new Cliente{ Cpf = "33333", Nome = "Marisa" }}
        };


        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("====       Atendimento       ====");
                    Console.WriteLine("====  1 - Cadastrar Conta    ====");
                    Console.WriteLine("====  2 - Listar Contas      ====");
                    Console.WriteLine("====  3 - Remover Conta      ====");
                    Console.WriteLine("====  4 - Ordenar Contas     ====");
                    Console.WriteLine("====  5 - Pesquisar Conta    ====");
                    Console.WriteLine("====  6 - Sair do Sistema    ====");
                    Console.WriteLine("=================================");

                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
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
                            PesquisarConta();
                            break;
                        case '6':
                            SairDoSistema();
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }

                }
            }
            catch (ByteBankException excecao)
            {

                Console.WriteLine($"{excecao.Message}");
            }
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("====    CADASTRO DE CONTAS    ====");
            Console.WriteLine("==================================");
            Console.WriteLine("\n");
            Console.WriteLine("==== Informe os dados da conta ===");

            Console.Write("\nNúmero da agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);

            Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");

            Console.Write("\nInforme o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("\nInforme o nome do titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("\nInforme o CPF do titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("\nInforme a profissão do titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);

            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("====      LISTA DE CONTAS      ====");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }

            foreach (ContaCorrente item in _listaDeContas)
            {
                Console.WriteLine("===  Dados da Conta  ===");
                Console.WriteLine("Número da Conta: " + item.Conta);
                Console.WriteLine("Número da Agência: " + item.Numero_agencia);
                Console.WriteLine("Saldo da Conta: " + item.Saldo);
                Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
                Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
                Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                Console.WriteLine("\n");
            }

            Console.ReadKey();
        }

        private void RemoverConta()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("====     REMOVER DE CONTAS     ====");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");

            Console.Write("Informe o número da Conta: ");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;

            foreach (ContaCorrente item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }

            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoção não encontrada ...");
            }

            Console.ReadKey();
        }

        private void OrdenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenada com sucesso! ...");
            Console.ReadKey();
        }

        private void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("====      PESQUISAR CONTA      ====");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");

            List<ContaCorrente> contas = new List<ContaCorrente>();

            Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA, (2) CPF TITULAR ou (3) Nº AGÊNCIA? ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Informe o número da conta: ");
                    string _numeroConta = Console.ReadLine();

                    ContaCorrente contaPorNumero = ConsultarPorNumeroConta(_numeroConta);
                    contas.Add(contaPorNumero);

                    //conta = ConsultarContaGeneric(conta => conta.Conta == _numeroConta); //Consulta pasando um lambda por parâmetro
                    break;

                case 2:
                    Console.Write("Informe o CPF do titular: ");
                    string _cpfTitular = Console.ReadLine();

                    ContaCorrente contaPorPDF = ConsultarPorCPFTitular(_cpfTitular);
                    contas.Add(contaPorPDF);

                    //conta = ConsultarContaGeneric(conta => conta.Titular.Cpf == _cpfTitular); //Consulta pasando um lambda por parâmetro
                    break;

                case 3:
                    Console.Write("Informe o N° da Agência: ");
                    int _numeroAgencia = int.Parse(Console.ReadLine());
                    var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                    contas.AddRange(contasPorAgencia);

                    break;

                default:
                    Console.WriteLine("\nOpção náo implementada!");
                    Console.ReadKey();
                    return;
            }

            if (contas.Count > 0)
            {
                foreach (ContaCorrente conta in contas)
                    Console.WriteLine(conta.ToString());
            }
            else
            {
                Console.WriteLine("\n... Não há contas para a pesquisa solicitada ...");
            }

            Console.ReadKey();
        }

        private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            var consulta = (
                from conta in _listaDeContas
                where conta.Numero_agencia == numeroAgencia
                select conta
            ).ToList();

            return consulta;
        }

        private void SairDoSistema()
        {
            Console.WriteLine("... Encerrando a aplicação ...");
            Console.ReadKey();
        }

        private ContaCorrente ConsultarPorNumeroConta(string numeroConta)
        {

            //foreach (ContaCorrente item in _listaDeContas)
            //{
            //    if (item.Conta.Equals(numeroConta))
            //        return item;

            //}

            //return null;

            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }

        private ContaCorrente ConsultarPorCPFTitular(string? cpfTitular)
        {
            //foreach (ContaCorrente item in _listaDeContas)
            //{
            //    if (item.Titular.Cpf.Equals(cpfTitular))
            //        return item;
            //}

            //return null;

            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpfTitular).FirstOrDefault();
        }

        private ContaCorrente ConsultarContaGeneric(Func<ContaCorrente, bool> lambda)
        {
            return _listaDeContas.Where(lambda).FirstOrDefault();
        }

        #region Exemplos de uso do List e outras coleções

        //List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
        //{
        //    new ContaCorrente(874, "984623-A"),
        //    new ContaCorrente(874, "656512-B"),
        //    new ContaCorrente(874, "852322-C")
        //};

        //List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
        //{
        //    new ContaCorrente(951, "454522-E"),
        //    new ContaCorrente(321, "541154-F"),
        //    new ContaCorrente(719, "321123-G")
        //};

        //_listaDeContas2.AddRange(_listaDeContas3);
        //_listaDeContas2.Reverse();

        //for (int i = 0; i < _listaDeContas2.Count; i++)
        //{
        //    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
        //}

        //Console.WriteLine("\n\n");

        //var range = _listaDeContas3.GetRange(0, 1);

        //for (int i = 0; i < range.Count; i++)
        //{
        //    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
        //}

        //Console.WriteLine("\n\n");

        //_listaDeContas3.Clear();

        //for (int i = 0; i < _listaDeContas3.Count; i++)
        //{
        //    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas3[i].Conta}]");
        //}

        //DesafioDosNomesEscolhidos();
        private void DesafioDosNomesEscolhidos()
        {
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

            string nomeProcurado = "Anakin Wayne";

            Console.WriteLine("Os escolhidos de hoje são:");

            foreach (string nome in nomesDosEscolhidos)
                Console.WriteLine("- " + nome);

            Console.WriteLine("\n");
            Console.WriteLine("O nome procurado de hoje é: " + nomeProcurado);

            Console.WriteLine("\n");

            Console.WriteLine($"O nome {nomeProcurado} {(ElementoExiste(nomesDosEscolhidos, nomeProcurado) ? string.Empty : "não")} existe na lista dos escolhidos.");
        }

        private bool ElementoExiste(List<string> nomes, string nome)
        {
            return nomes.Contains(nome);
        }


        // ------ SortedList --------
        //private SortedList<int, string> times = new SortedList<int, string>();
        //times.Add(0, "Flamengo");
        //times.Add(1, "Santos");
        //times.Add(2, "Juventus");

        //foreach (var item in times.Values)
        //{
        //    Console.WriteLine(item);
        //}

        // ------ Stack --------
        //private Stack<string> minhlaPilhaDeLivros = new Stack<string>();
        //minhlaPilhaDeLivros.Push("Harry Porter e a Ordem da Fênix");
        //minhlaPilhaDeLivros.Push("A Guerra do Velho.");
        //minhlaPilhaDeLivros.Push("Protocolo Bluehand");
        //minhlaPilhaDeLivros.Push("Crise nas Infinitas Terras.");

        //Console.WriteLine(minhlaPilhaDeLivros.Peek());// Retorna o elemento do topo.
        //Console.WriteLine(minhlaPilhaDeLivros.Pop()); //Remove o elemento do topo


        // ------ Queue ------
        //Queue<string> filaAtendimento = new Queue<string>();
        //filaAtendimento.Enqueue("André Silva");
        //filaAtendimento.Enqueue("Lou Ferrigno");
        //filaAtendimento.Enqueue("Gal Gadot");

        //filaAtendimento.Dequeue();//Remove o primeiro elemento da fila.


        // ------ HashSet -----
        //HashSet<int> _numeros = new HashSet<int>();
        //_numeros.Add(0);
        //_numeros.Add(1);
        //_numeros.Add(1);
        //_numeros.Add(1);

        //Console.WriteLine(_numeros.Count);// a saída é 2.

        //foreach (var item in _numeros)
        //{
        //    Console.WriteLine(item);
        //}

        #endregion
    }
}
