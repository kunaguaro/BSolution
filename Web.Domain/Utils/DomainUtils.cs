using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Utils
{
    public class DomainUtils
    {
        public static string ObtenerPalabras(string input, int nroCaracteres)
        {
            try
            {

                int nchar = nroCaracteres;

                for (int i = 0; i < input.Length; i++)
                {
                    nchar--;
                    if (nchar == 0)
                    {
                        return input.Substring(0, i);
                    }
                }
            }
            catch (Exception)
            {
                // to do
            }
            return string.Empty;
        }
    }
}
