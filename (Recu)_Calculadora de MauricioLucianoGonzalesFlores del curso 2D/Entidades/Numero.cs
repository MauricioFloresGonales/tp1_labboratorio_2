using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        double numeroIngresado;

        public Numero()
        {
            this.numeroIngresado = 0;
        }
        public double NumeroIngresado
        {
            get { return this.numeroIngresado; }
        }

        private double ValidarNumero(string numero)
        {
            double retorno = 0;
            if(double.TryParse(numero, out retorno))
            {
                return retorno;
            }
            return retorno;
        }

        public void SetNumero(Numero numeroAIngresar, string numero)
        {
            this.numeroIngresado = ValidarNumero(numero);
        }

        private static bool EsBinario(string numeroBinario)
        {
            bool retorno = false;
            char caracterCero = '0';
            char caracterUno = '1';

            for (int i = 0; i < numeroBinario.Length; i++)
            {
                if (numeroBinario[i] != caracterCero && numeroBinario[i] != caracterUno)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static string BinarioDecimal(double numero)
        {
            decimal numeroFinal;
            string numeroEnString = numero.ToString();

            if (EsBinario(numeroEnString))
            {
                numeroFinal = (decimal)numero;
                return numeroEnString = numeroFinal.ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        public static string DecimalBinario(double numero)
        {
            int auxNumero = (int)numero;
            string numeroBinario = "";
            if (auxNumero > 0)
            {
                while (auxNumero > 0)
                {
                    if (auxNumero % 2 == 0)
                    {
                        numeroBinario = "0" + numeroBinario;
                    }
                    else
                    {
                        numeroBinario = "1" + numeroBinario;
                    }
                    auxNumero = (int)(auxNumero / 2);
                }
                return numeroBinario;
            }
            else
            {
                if (auxNumero == 0)
                {
                    numeroBinario = "0";
                }
                else
                {
                    numeroBinario = "Valor invalido";
                }
            }
            return numeroBinario;
        }
    }
}
