using KPO_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App
{
    /// <summary>
    /// Интерфейс форм второго уровня
    /// </summary>
    public interface IFormsInterfacerm
    {
        /// <summary>
        /// Получение формы
        /// </summary>
        /// <returns></returns>
        Phone GetPiece();

        /// <summary>
        /// Открыть форму
        /// </summary>
        /// <returns></returns>
        bool Open();
    }
}
