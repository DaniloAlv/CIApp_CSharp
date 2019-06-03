using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIApp
{
    class CIApp
    {
        static int Main()
        {
            int op;
            Formulario f = new Formulario();

            do
            {
                Console.WriteLine("\tCI APP MENU\n");
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1) Novo formulário");
                Console.WriteLine("2) Buscar formulário");
                Console.WriteLine("3) Atualizar formulário");
                Console.WriteLine("4) Excluir formulário");
                Console.WriteLine("0) Sair do Menu");

                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Clear();
                        f.InsereFormulario();
                        break;
                    case 2:
                        Console.Clear();
                        f.BuscaFormulario();
                        break;
                    case 3:
                        Console.Clear();
                        f.AtualizaFormulario();
                        break;
                    case 4:
                        Console.Clear();
                        f.RemoveFormulario();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            }
            while (op != 0);
            Console.WriteLine("Saindo...");

            return 0;
        }
    }
}
