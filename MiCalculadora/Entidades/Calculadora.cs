using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    { 
        /// <summary>
        /// Valida si el operador es correcto.
        /// </summary>
        /// <param name="operador">El operador de la calculadora.</param>
        /// <returns>Retorna el operador en caso de ser correcto, sino retornara +</returns>
        /// 
        private static string ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                return '+'.ToString();
            }

            return operador.ToString(); ;
        }

        /// <summary>
        /// Realiza la ecuacion de la calculadora.
        /// </summary>
        /// <param name="num1">Primer operando.</param>
        /// <param name="num2">Segundo operando.</param>
        /// <param name="operador">Operador para realizar la ecuacion.</param>
        /// <returns>Retorna el resultado.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            char operacion = operador[0];
            operador = ValidarOperador(operacion);

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
    }
}
