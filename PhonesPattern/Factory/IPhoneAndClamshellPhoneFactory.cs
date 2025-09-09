using KPO_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.Factory
{
    /// <summary>
    /// Фабрика для айфона и телефон-раскладушка
    /// </summary>
    public class IPhoneAndClamshellPhoneFactory : AbstractPhoneFactory
    {
        /// <summary>
        /// Создание айфона
        /// </summary>
        /// <returns></returns>
        public override Smartphone CreateSmartphone()
        {
            return new IPhone();
        }

        /// <summary>
        /// Создание телефон-раскладушка
        /// </summary>
        /// <returns></returns>
        public override FeaturePhone CreateFeaturePhone()
        {
            return new ClamshellPhone();
        }

        /// <summary>
        /// Названия
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Айфон и Телефон-раскладушка";
        }
    }
}
