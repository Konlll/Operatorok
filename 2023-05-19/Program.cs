using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace _2023_05_19
{
    internal class Program
    {
        static List<Operation> operations = new List<Operation>();
        static Dictionary<string, int> operators = new Dictionary<string, int>()
        {
            { "mod", 0 }, { "/", 0 }, {"div", 0 }, { "-", 0 }, {"*", 0 }, {"+", 0}
        };
        static void Main(string[] args)
        {
            operations = File.ReadAllLines("kifejezesek.txt").Select(x => new Operation(x)).ToList();

            Console.WriteLine($"2. feladat: Kifejezések száma: {operations.Count()}");
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {operations.Count(x => x.getOperator() == "mod")}");
            string message = operations.Find(x => x.getOperand1() % 10 == 0 && x.getOperand2() % 10 == 0) != null ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!";
            Console.WriteLine($"4. feladat: {message}");

            Console.WriteLine("5. feladat: Statisztika");
            foreach (Operation op in operations)
            {
                switch(op.getOperator())
                {
                    case "+":
                        operators["+"]++;
                        break;
                    case "-":
                        operators["-"]++;
                        break;
                    case "*":
                        operators["*"]++;
                        break;
                     case "/":
                        operators["/"]++;
                        break;
                    case "mod":
                        operators["mod"]++;
                        break;
                    case "div":
                        operators["div"]++;
                        break;
                    default:
                        break;
                }
            }

            foreach(KeyValuePair<string, int> op in operators)
            {
                Console.WriteLine($"\t{op.Key} - {op.Value} db");
            }

            string operation = "";

            while(true)
            {
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                operation = Console.ReadLine();
                if(operation == "vége")
                {
                    break;
                }

                var fields = operation.Split(' ');
                Operation theOperation = new Operation(int.Parse(fields[0]), fields[1], int.Parse(fields[2]));
                Console.WriteLine($"\t{operation} = {getValue(theOperation)}");
            }

            Console.WriteLine("8. feladat: eredmenyek.txt");
            StreamWriter sw = new StreamWriter("eredmenyek.txt");
            operations.ForEach(x=>sw.WriteLine($"{x.getOperand1()} {x.getOperator()} {x.getOperand2()} = {getValue(x)}"));
            sw.Close();

        }

        private static string getValue(Operation operation)
        {
            List<string> operators = new List<string>() { "+", "-", "/", "*", "mod", "div" };
            if (!operators.Contains(operation.getOperator()))
            {
                return "Hibás operátor!";
            }
            else
            {
                switch (operation.getOperator())
                {
                    case "+":
                        return (operation.getOperand1() + operation.getOperand2()).ToString();
                    case "-":
                        return (operation.getOperand1() - operation.getOperand2()).ToString();
                    case "*":
                        return (operation.getOperand1() * operation.getOperand2()).ToString();
                    case "/":
                        return operation.getOperand2() == 0 ? "Egyéb hiba!" : ((double)operation.getOperand1() / operation.getOperand2()).ToString();
                    case "mod":
                        return operation.getOperand2() == 0 ? "Egyéb hiba!" : (operation.getOperand1() % operation.getOperand2()).ToString();
                    case "div":
                        return operation.getOperand2() == 0 ? "Egyéb hiba!" : (operation.getOperand1() / operation.getOperand2()).ToString();
                    default:
                        break;
                }
            }
            return "";
        }
    }
}
