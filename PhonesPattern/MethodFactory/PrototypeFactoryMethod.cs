using KPO_1;
using PhonesPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.MethodFactory
{
    /// <summary>
    ///абричный метод для создания фабрики прототипов телефонов
    /// </summary>
    public class PrototypeFactoryMethod : AbstractMethodPhoneFactory
    {
        /// <summary>
        /// Смартфон
        /// </summary>
        private Smartphone _smartphone;

        /// <summary>
        /// Обычный телефон
        /// </summary>
        private FeaturePhone _featurePhone;

        /// <summary>
        /// Конструктор фабрики прототипов
        /// </summary>
        /// <param name="parSmartphone">Смартфон</param>
        /// <param name="parFeaturePhone">Обфчный телефон</param>
        public PrototypeFactoryMethod(Smartphone parSmartphone, FeaturePhone parFeaturePhone)
        {
            _smartphone = (Smartphone)parSmartphone.Clone();
            _featurePhone = (FeaturePhone)parFeaturePhone.Clone();
        }
        public override IFactoryPhone CreateFactory()
        {
            return new PrototypeFactory(_smartphone, _featurePhone);
        }
    }
}
