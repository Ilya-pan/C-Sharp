using KPO_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.Factory
{
    /// <summary>
    /// Фабрика для Андроида и Моноблочный телефон
    /// </summary>
    public class AndroidAndCandyBarPhoneFactory : AbstractPhoneFactory
    {
        /// <summary>
        /// Создание андроида
        /// </summary>
        /// <returns></returns>
        public override Smartphone CreateSmartphone()
        {
            return new AndroidPhone();
        }

        /// <summary>
        /// Создание Моноблочного телефона
        /// </summary>
        /// <returns></returns>
        public override FeaturePhone CreateFeaturePhone()
        {
            return new CandyBarPhone();
        }

        /// <summary>
        /// Названия
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Андроид и Моноблочный телефон";
        }
    }
}
