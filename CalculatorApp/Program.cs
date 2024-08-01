using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CalculatorApi;

namespace CalculatorApp
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var baseUrl = "http://localhost:5093"; ;
            string connectionString = "data source=WINDOWS-4QT2NDK;initial catalog=CalcLogDB;user id=sa;password=11Jan02*;trustservercertificate=True;MultipleActiveResultSets=True;";
            
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<SPDiagnostics>()
                .As<IDiagnostics>()
                .WithParameter("connectionString", connectionString);
            containerBuilder.RegisterType<Calculator>().As<ICalculator>();
            containerBuilder.RegisterType<CalculatorApiClient>().As<ICalculatorAsync>();

            var container = containerBuilder.Build();
            Console.WriteLine("container has been built");

            var calc = container.Resolve<ICalculator>();

            int a, b;

            Console.Write("Enter first number : ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number : ");
            b = int.Parse(Console.ReadLine());

            try
            {

                var addResult = await CallApiAsync($"{baseUrl}/add?start={a}&amount={b}");
                var subtractResult = await CallApiAsync($"{baseUrl}/subtract?start={a}&amount={b}");
                var multiplyResult = await CallApiAsync($"{baseUrl}/multiply?start={a}&by={b}");
                var divideResult = await CallApiAsync($"{baseUrl}/divide?start={a}&by={b}");

                //var addResult = calc.Add(a, b);
                //var subtractResult = calc.Subtract(a, b);
                //var multiplyResult = calc.Multiply(a, b);
                //var divideResult = calc.Divide(a, b);

                Console.WriteLine($"Add: {a} + {b} = " + addResult);
                Console.WriteLine($"Subtract: {a} - {b} = " + subtractResult);
                Console.WriteLine($"Multiply: {a} * {b} = " + multiplyResult);
                Console.WriteLine($"Divide: {a} / {b} = " + divideResult);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        private static async Task<string> CallApiAsync(string url)
        {
            try
            {
                var response = await client.GetStringAsync(url);
                return response;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }
    }
}
