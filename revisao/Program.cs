using System;

namespace csharp_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indceAluno = 0;

            string opcaoUsuario = ObteropcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        // TODO: adicionar aluno
                        Console.WriteLine("Digite o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine($"Digite oa nota do aluno {aluno.Nome}: ");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indceAluno] =aluno;
                        indceAluno ++;
                        break;

                    case "2":
                        // TODO: lista alunos
                        foreach (var a in alunos)
                        {
                            // ! é usada para inverter a logica aplicada
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        // TODO: calcular media geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                nrAlunos ++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral:f2} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        // agumento está fora da informação listada no switch
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObteropcaoUsuario();
            }
        }

        private static string ObteropcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir alunos");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            Console.Write("OPÇÃO: ");
            string opcaoUsuario = Console.ReadLine();
            
            
            return opcaoUsuario;
        }
    }
}
