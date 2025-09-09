using PhonesPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.MethodFactory
{
    /// <summary>
    /// Абстрактный фабричный метод
    /// </summary>
    public abstract class AbstractMethodPhoneFactory : IFactoryPhoneMethod
    {
        /// <summary>
        /// Создание фабрики
        /// </summary>
        /// <returns></returns>
        public abstract IFactoryPhone CreateFactory();
    }
}
