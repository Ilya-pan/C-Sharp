using PhonesPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.MethodFactory
{
    /// <summary>
    ///  Фабричный метод для создания айфона и телефон-раскладушка
    /// </summary>
    public class IPhoneAndClamshellPhoneMethod : AbstractMethodPhoneFactory
    {
        /// <summary>
        /// Создание фабрики айфона и телефон-раскладушка
        /// </summary>
        /// <returns></returns>
        public override IFactoryPhone CreateFactory()
        {
            return new IPhoneAndClamshellPhoneFactory();
        }
    }
}
