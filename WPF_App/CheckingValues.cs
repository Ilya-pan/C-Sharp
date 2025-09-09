using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App
{
    /// <summary>
    /// Проверка значений
    /// </summary>
    class CheckingValues
    {
        /// <summary>
        /// Проверка на целое число
        /// </summary>
        /// <param name="parValue"></param>
        /// <returns></returns>
        public static bool IsInt(string parValue)
        {
            return int.TryParse(parValue, out _);
        }

        /// <summary>
        /// Проверка на вещественное число
        /// </summary>
        /// <param name="parValue"></param>
        /// <returns></returns>
        public static bool IsFloat(string parValue)
        {
            return float.TryParse(parValue, out _);
        }
    }
}
