using System;
using System.Collections.Generic;
using System.Linq;

namespace interpretador_de_expressões
{
    class Program
    {
        public static string Result;

        static void Main()
        {
            while (string.IsNullOrEmpty(Result))
            {
                try
                {
                    Console.WriteLine("Digite a Expressão");
                    var characteres = Console.ReadLine()?.ToCharArray()?.Where(x => x != '(' && x != ' ')?.Select(x => x.ToString());
                    if (!(characteres?.Any() ?? false))
                        throw new Exception($"Informe os dados corretamente pra realizar o cálculo");

                    var operands = new Stack<int>();
                    var operators = new Stack<OperatorsEnum>();

                    foreach (var c in characteres)
                    {
                        if (c == ")")
                            operands.Push(Calculate(operators, operands).Value);
                        else if (int.TryParse(c, out int newOperand))
                            operands.Push(newOperand);
                        else if (GetOperator(c) != OperatorsEnum.Unknown)
                            operators.Push(GetOperator(c));
                        else
                            throw new Exception($"Caractere informado é inválido: {c}");

                    }

                    while (operands.Count > 1)
                        operands.Push(Calculate(operators, operands).Value);

                    Result = operands.Peek().ToString();
                }
                catch (Exception e)
                {
                    Result = null;
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("O resultado gerado foi: " + Result);
        }

        private static int? Calculate(Stack<OperatorsEnum> operators, Stack<int> operands)
        {
            if (operands?.Count < 2 && operators?.Count < 1)
                throw new Exception($"Informe os dados corretamente pra realizar o cálculo");

            var secondNumber = operands.Peek();
            operands.Pop();

            var firstNumber = operands.Peek();
            operands.Pop();

            var contOperator = operators.Peek();
            operators.Pop();

            int? result = contOperator switch
            {
                OperatorsEnum.Plus => firstNumber + secondNumber,
                OperatorsEnum.Minus => firstNumber - secondNumber,
                OperatorsEnum.Multi => firstNumber == 0 || secondNumber == 0 ? null : firstNumber * secondNumber,
                _ => null
            };

            if (result == null)
                throw new Exception($"Informe os dados corretamente pra realizar o cálculo");

            return result;
        }

        private static OperatorsEnum GetOperator(string op)
        {
            return op switch
            {
                "+" => OperatorsEnum.Plus,
                "-" => OperatorsEnum.Minus,
                "*" => OperatorsEnum.Multi,
                _ => OperatorsEnum.Unknown
            };
        }

        private enum OperatorsEnum
        {
            Unknown,
            Plus,
            Minus,
            Multi
        }

    }
}
