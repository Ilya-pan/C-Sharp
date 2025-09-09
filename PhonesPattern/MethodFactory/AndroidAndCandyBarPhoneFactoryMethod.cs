using PhonesPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.MethodFactory
{
    /// <summary>
    /// Фабричный метод для создания андроида и моноблочного телефона
    /// </summary>
    public class AndroidAndCandyBarPhoneFactoryMethod : AbstractMethodPhoneFactory
    {
        /// <summary>
        /// Создание фабрики андроида и моноблочного телефона
        /// </summary>
        /// <returns></returns>
        public override IFactoryPhone CreateFactory()
        {
            return new AndroidAndCandyBarPhoneFactory();
        }
    }
}
