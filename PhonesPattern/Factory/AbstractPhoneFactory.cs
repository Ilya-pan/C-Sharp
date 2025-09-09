using KPO_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.Factory
{
    /// <summary>
    /// Абстрактная фабрика
    /// </summary>
    public abstract class AbstractPhoneFactory : IFactoryPhone
    {
        /// <summary>
        /// Создание смартфона
        /// </summary>
        /// <returns></returns>
        public abstract Smartphone CreateSmartphone();

        /// <summary>
        /// Создание обычного телефона
        /// </summary>
        /// <returns></returns>
        public abstract FeaturePhone CreateFeaturePhone();
    }
}
