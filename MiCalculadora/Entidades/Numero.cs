using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /* ATRIBUTOS */
        private double numero;

        /* PROPIEDADES */
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /* METODOS */

        /// <summary>
        /// Valida si la cadena es binaria.
        /// </summary>
        /// <param name="binario">String a validar.</param>
        /// <returns>True si la cadena es binaria, False caso contrario.</returns>
        private static bool EsBinario(string binario)
        {
            bool esBin = true;
            for (int i = 0; i < binario.Length - 1; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    esBin = false;
                    break;
                }
            }
            return esBin;
        }

        /// <summary>
        /// Valida la string pasada por parametro.
        /// </summary>
        /// <param name="numeroString">Cadena la cual sera validada si es numero o no.</param>
        /// <returns>Retorna un double, 0 si error.</returns>
        private double ValidarNumero(string numeroString)
        {
            double numeroDouble = 0;
            double.TryParse(numeroString, out numeroDouble);

            return numeroDouble;
        }

        /// <summary>
        /// Convierte cadena binaria a numero decimal.
        /// </summary>
        /// <param name="binario">Cadena a convertir.</param>
        /// <returns>Numero decimal equivalente o mensaje de error.</returns>
        public static string BinarioDecimal(string binario)
        {
            char[] arrayBinario = binario.ToCharArray();
            Array.Reverse(arrayBinario); // invertir array
            string retorno = "Valor Invalido";
            int sumaDecimal = 0;

            if (EsBinario(binario))
            {
                //si es binario, borro el mensaje de error
                retorno = string.Empty;

                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if (arrayBinario[i] == '1')
                    {
                        // si es 1, sumo 2 elevado a la indice al acumulador
                        sumaDecimal += (int)Math.Pow(2, i);
                    }
                }
                //convierto el resultado en string y lo asigno al retorno
                retorno = sumaDecimal.ToString();
            }
            return retorno;
        }

        /*
        public string DecimalBinario(double numero) {
            string strBinario = string.Empty;
            char[] arrayBinario; // donde almacenare el string para invertir

            while ((numero >= 1)){ 
                strBinario += numero % 2;
                numero /= 2;
            }

            // paso a char y guardo en array
            arrayBinario = strBinario.ToCharArray();
            //vacio el string para reutilizar
            strBinario = string.Empty;
            // invierto el array
            Array.Reverse(arrayBinario);
            //paso array a string ya invertido
            for (int i = 0; i < arrayBinario.Length; i++){
                strBinario += arrayBinario[i];
            }
            return strBinario;
        }*/

        /// <summary>
        /// Convierte numero con coma a binario.
        /// </summary>
        /// <param name="numero">Numero a ser convertido.</param>
        /// <returns>Retorna una cadena binaria o mensaje de error.</returns>
        public static string DecimalBinario(double numero)
        {
            string strBinario = "Valor Invalido";
            if (numero >= 0)
            {
                //si es positivo, borro mensaje de error
                strBinario = string.Empty;
                if (numero == 0)
                {
                    strBinario = "0"; // Si el numero de parametro es 0, muestro 0
                }

                while (numero > 0)
                {
                    strBinario = (int)numero % 2 + strBinario;
                    numero = (int)numero / 2;
                }
            }

            return strBinario;
        }

        /// <summary>
        /// Convierte cadena numero a binario.
        /// </summary>
        /// <param name="numero">Numero a ser convertido.</param>
        /// <returns>Retorna una cadena binaria o mensaje de error.</returns>
        public static string DecimalBinario(string numero)
        {
            string resultado = string.Empty;//cadena vacia
            //parseo la cadena a double
            double.TryParse(numero, out double numeroDouble);
            //convierto el double a string binario
            resultado = DecimalBinario(numeroDouble);

            return resultado;
        }

        /* BUILDER OVERFLOW */

        /// <summary>
        /// Setea en 0 el numero por default.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Asigna numero al campo numero.
        /// </summary>
        /// <param name="numero">Numero a asignar</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// convierte una cadena a double y asigna en campo numero.
        /// </summary>
        /// <param name="numero">Cadena numerica a asignar.</param>
        public Numero(string numero)
        {
            bool convirtio = double.TryParse(numero, out double numeroDouble);
            if (convirtio)
            {
                this.numero = numeroDouble;
            }
        }

        /* OPERATORS OVERFLOW */

        /// <summary>
        /// Sobrecarga operador -.
        /// </summary>
        /// <param name="n1">Primer Objeto operando.</param>
        /// <param name="n2">Segundo Objeto operando</param>
        /// <returns>Retorna la resta entre ambos objetos.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador *.
        /// </summary>
        /// <param name="n1">Primer Objeto operando.</param>
        /// <param name="n2">Segundo Objeto operando</param>
        /// <returns>Retorna la multiplicacion entre ambos objetos.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador /.
        /// </summary>
        /// <param name="n1">Primer Objeto operando.</param>
        /// <param name="n2">Segundo Objeto operando</param>
        /// <returns>Retorna la division entre ambos objetos, si el segundo es 0, devolvera una constante.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }

        /// <summary>
        /// Sobrecarga operador +.
        /// </summary>
        /// <param name="n1">Primer Objeto operando.</param>
        /// <param name="n2">Segundo Objeto operando</param>
        /// <returns>Retorna la suma entre ambos objetos.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
