using KPO_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.Factory
{
    /// <summary>
    /// Интерфейс фабрики
    /// </summary>
    public interface IFactoryPhone
    {
        /// <summary>
        /// Создание смартфона
        /// </summary>
        /// <returns></returns>
        Smartphone CreateSmartphone();

        /// <summary>
        /// Создание обычного телефона
        /// </summary>
        /// <returns></returns>
        FeaturePhone CreateFeaturePhone();
    }
}
