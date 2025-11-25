using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private string regexPlaca = "^(?:[A-Z]{3}-?[0-9]{4}|[A-Z]{3}[0-9][A-Z][0-9]{2})$";
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().Trim().ToUpper();

            if (Regex.IsMatch(placa, this.regexPlaca))
            {
                veiculos.Add(placa);
                Console.WriteLine($"SUCESSO! Veículo com a placa {placa} adicionado ao estacionamento.\n");
            }
            else
            {
                Console.WriteLine("[ ERROR ] Placa inválida. Tente novamente.\n");
            }
        }

        public void RemoverVeiculo()
        {
            int horas = 0;
            decimal valorTotal = 0;

            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().Trim().ToUpper();

            if (Regex.IsMatch(placa, this.regexPlaca))
            {
                if (veiculos.Any(x => x == placa))
                {

                    while (true)
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out horas) && horas >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[ ERROR ] Entrada inválida. Por favor, digite um número inteiro maior que zero.\n");
                        }
                    }

                    valorTotal = this.precoInicial + this.precoPorHora * horas;

                    this.veiculos.Remove(placa);

                    Console.WriteLine($"SUCESSO! O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}\n");
                }
                else
                {
                    Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.\n");
                }
            }
            else
            {
                Console.WriteLine("[ ERROR ] Placa inválida. Tente novamente.\n");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
