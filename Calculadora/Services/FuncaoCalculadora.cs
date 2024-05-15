using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Services
{
    public class FuncaoCalculadora
    {
        private List<string> listaHistorico;
        public FuncaoCalculadora()
        {
            listaHistorico = new List<string>();
        }

        public int Somar(int num1, int num2)
        {
            int resultado = num1 + num2;
            listaHistorico.Insert(0, "Resultado: " + resultado);

            return resultado;
        }

        public int Subtrair(int num1, int num2)
        {
            int resultado = num1 - num2;
            listaHistorico.Insert(0, "Resultado: " + resultado);

            return resultado;
        }

        public int Multiplicar(int num1, int num2)
        {
            int resultado = num1 * num2;
            listaHistorico.Insert(0, "Resultado: " + resultado);

            return resultado;
        }

        public int Dividir(int num1, int num2)
        {
            int resultado = num1 / num2;
            listaHistorico.Insert(0, "Resultado: " + resultado);

            return resultado;
        }

        public int Potencia(int num1, int num2)
        {
            int resultado = (int)Math.Pow(num1, num2);
                // Utilizando a classe MATH e declarando o tipo INT para realizar a operação de potencia
            
            listaHistorico.Insert(0, "Resultado: " + resultado);

            return resultado;
        }

        public List<string> historico()
        {
                // Se a lista possuir vários elementos, será retornado SOMENTE os 3 mais recentes. Os elementos antigos serão ignorados
            if(listaHistorico.Count > 3)
            {
                listaHistorico.RemoveRange(0, listaHistorico.Count -3);
            }

            return listaHistorico;
        }
    }
}