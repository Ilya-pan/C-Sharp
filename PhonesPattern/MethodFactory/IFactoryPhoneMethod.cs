using PhonesPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.MethodFactory
{
    /// <summary>
    /// Интерфейс фабричного метода
    /// </summary>
    public interface IFactoryPhoneMethod
    {
        /// <summary>
        /// Создание фабрики
        /// </summary>
        /// <returns></returns>
        IFactoryPhone CreateFactory();
    }
}
