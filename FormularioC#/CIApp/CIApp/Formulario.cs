using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIApp
{
    class Formulario
    {
        private List<Formulario> Form = new List<Formulario>();
        private int Id { get; set; }
        private string Remetente { get; set; }
        private string Destinatario { get; set; }
        private string Mensagem { get; set; }
        private DateTime Data { get; set; }

        public void InsereFormulario()
        {
            int id = 0;
            int buscaMaiorId = 0;

            Console.WriteLine("Entre com seu nome");
            string rem = Console.ReadLine();
            Console.WriteLine("Entre com o destinatário");
            string dest = Console.ReadLine();
            Console.WriteLine("Digite sua mensagem");
            string msg = Console.ReadLine();

            if (Form.Count == 0)
                id = 1;
            else
                buscaMaiorId = Form.OrderBy(f => f.Id).Select(f => f.Id).ToArray().Max();
                id = buscaMaiorId + 1;  
            
            try
            {
                Form.Add(new Formulario() { Id = id, Remetente = rem, Destinatario = dest, Mensagem = msg, Data = DateTime.Now });
                Console.Clear();
                Console.WriteLine("Formulário realizado com sucesso");
                Console.WriteLine("Este é seu Número de registro, por favor não o perca: " + id);
                Console.WriteLine("Para fazer qualquer alteração ou simplesmente procurar seu formulário, precisará informa-lo");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro " + e.Message);
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void BuscaFormulario()
        {
            Console.WriteLine("Informe o número de registro do seu formulário");
            int id = int.Parse(Console.ReadLine());

            try
            {
                Form.Where(f => f.Id == id).ToList().ForEach(f => Console.WriteLine(f.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Formulário não encontrado " + e.Message);
            }
            
            Console.ReadKey();
            Console.Clear();
        }

        public void AtualizaFormulario()
        {
            int op;
            Console.WriteLine("Para qualquer atualização no formulário, informe o número de registro do mesmo");
            int id = int.Parse(Console.ReadLine());

            var buscaRemetente = Form.Where(f => f.Id == id).Select(f => f.Remetente).FirstOrDefault();

            do
            {
                Console.WriteLine("O que deseja editar no formulário " + buscaRemetente);
                Console.WriteLine("1) Alterar o remetente");
                Console.WriteLine("2) Alterar o destinatário");
                Console.WriteLine("3) Reescrever mensagem");
                Console.WriteLine("0) Voltar");

                op = int.Parse(Console.ReadLine());

                var busca = Form.Find(f => f.Id == id);

                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Informe o novo nome do remetente");
                        busca.Remetente = Console.ReadLine();
                        Console.WriteLine("Remetente Alterado com sucesso");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Informe o novo nome do destinatário");
                        busca.Destinatario = Console.ReadLine();
                        Console.WriteLine("Destinatário Alterado com sucesso");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Digite uma nova mensagem para substituir a antiga");
                        busca.Mensagem = Console.ReadLine();
                        Console.WriteLine("Nova mensagem foi salva com sucesso");
                        break;
                }

            } while (op != 0);
            
        }

        public void RemoveFormulario()
        {
            char resp;

            Console.WriteLine("Informe o número de registro do seu formulário");
            int id = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Tem certeza de que deseja remover o formulário?\nEssa ação não poderá ser desfeita");
            Console.Write("S / N ");
            resp = char.Parse(Console.ReadLine());

            if (resp == 's' || resp == 'S')
            {
                try
                {
                    var buscaPosicao = Form.FindIndex(f => f.Id == id);
                    Form.RemoveAt(buscaPosicao);
                    Console.WriteLine("Formulário removido com sucesso");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                } 
            }
            Console.ReadKey();
            Console.Clear();
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Remetente: " + Remetente + "\n" +
                   "Destinatário: " + Destinatario + "\n" +
                   "Mensagem: " + Mensagem + "\n" +
                   "Data: " + Data;
        }
    }
}
