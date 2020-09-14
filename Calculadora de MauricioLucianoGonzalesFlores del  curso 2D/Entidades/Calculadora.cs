using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static bool ValidarOperador(char operador)
        {
            bool retorno = false;

            string listaDeOperadores = "+-/*";

            for (int i = 0; i < listaDeOperadores.Length; i++)
            {
                if (listaDeOperadores[i] == operador)
                    retorno = true;
            }

            return retorno;
        }
        public static string operar (char operador, Numero numeroUno, Numero numeroDos)
        {
            double retorno = 0;
            if(ValidarOperador(operador))
            {
                switch (operador)
                {
                    case '-':
                        retorno = numeroUno.NumeroIngresado - numeroDos.NumeroIngresado;
                        break;
                    case '/':
                        if (numeroDos.NumeroIngresado == 0)
                        {
                            retorno = double.MinValue;
                        }
                        else
                        {
                            retorno = numeroUno.NumeroIngresado + numeroDos.NumeroIngresado;
                        }
                        break;
                    case '*':
                        retorno = numeroUno.NumeroIngresado + numeroDos.NumeroIngresado;
                        break;
                    default:
                        retorno = numeroUno.NumeroIngresado + numeroDos.NumeroIngresado;
                        break;
                }
            }
            return retorno.ToString();
        }
    }
}
