using System;
using TesteAudaz.Controllers;
using TesteAudaz.Models;
using TesteAudaz.Services;

namespace TesteAudaz
{
    class Program
    {
        static void Main(string[] args)
        {
            var fareController = new FareController();

            bool again = true;

            while (again)
            {
                var fare = new Fare();
                fare.Id = Guid.NewGuid();

                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                var fareValueInput = Console.ReadLine();
                fare.Value = decimal.Parse(fareValueInput);

                Console.WriteLine();
                Console.WriteLine("Informe o código da operadora para a tarifa:");
                Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                var operatorCodeInput = Console.ReadLine();

                fare.Date = DateTime.Now;
                fare.Status = 1;

                string resultFare = fareController.CreateFare(fare, operatorCodeInput);

                Console.WriteLine();

                if (resultFare != "sucess")
                {
                    Console.WriteLine(resultFare);
                }
                else
                {
                    Console.WriteLine("Tarifa cadastrada com sucesso!");
                }

                Console.WriteLine();
                Console.WriteLine("Deseja adicionar uma nova tarifa? (s/n)");
                string result = Console.ReadLine();

                if (string.IsNullOrEmpty(result) == false && result.ToLower() == "n")
                    again = false;

                Console.WriteLine();
            }
        }
    }
}