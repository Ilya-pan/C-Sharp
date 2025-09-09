using KPO_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesPattern.Factory
{
    /// <summary>
    /// Фабрика прототипов для создания телефонов
    /// </summary>
    public class PrototypeFactory : AbstractPhoneFactory
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
        public PrototypeFactory (Smartphone parSmartphone, FeaturePhone parFeaturePhone)
        {
            _smartphone = (Smartphone)parSmartphone.Clone();
            _featurePhone = (FeaturePhone)parFeaturePhone.Clone();
        }

        /// <summary>
        /// Создания копии смартфона
        /// </summary>
        /// <returns></returns>
        public override Smartphone CreateSmartphone()
        {
            return (Smartphone)_smartphone.Clone();
        }

        /// <summary>
        /// Создания копии обычного телефона
        /// </summary>
        /// <returns></returns>
        public override FeaturePhone CreateFeaturePhone()
        {
            return (FeaturePhone)_featurePhone.Clone();
        }

        /// <summary>
        /// Представление названия фабрики прототипов.
        /// </summary>
        /// <returns>Строка с названием фабрики</returns>
        public override string ToString()
        {
            return "Прототип";
        }
    }
}
