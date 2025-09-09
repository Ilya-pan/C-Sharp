using System.Security.Cryptography;
using System.Xml;

namespace KPO_1
{
    /// <summary>
    /// Базовый класс для представления телефона.
    /// </summary>
    public abstract class Phone
    {
        // Модель телефона.
        private string _modelName;

        // Год выпуска телефона.
        private int _yearOfManufacture;

        // Цена телефона.
        private decimal _phonePrice;

        // Уникальный идентификатор телефона.
        private Guid _phoneIdentifier;

        /// <summary>
        /// Модель телефона.
        /// </summary>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// <summary>
        /// Год выпуска телефона.
        /// </summary>
        public int YearOfManufacture
        {
            get { return _yearOfManufacture; }
            set { _yearOfManufacture = value; }
        }

        /// <summary>
        /// Цена телефона.
        /// </summary>
        public decimal PhonePrice
        {
            get { return _phonePrice; }
            set { _phonePrice = value; }
        }

        /// <summary>
        /// Уникальный идентификатор телефона.
        /// </summary>
        public Guid PhoneIdentifier
        {
            get { return _phoneIdentifier; }
            set { _phoneIdentifier = value; }
        }

        /// <summary>
        /// Конструктор класса Phone.
        /// </summary>
        /// <param name="parModelName">Модель телефона.</param>
        /// <param name="parYearOfManufacture">Год выпуска телефона.</param>
        /// <param name="parPhonePrice">Цена телефона.</param>
        public Phone(string parModelName, int parYearOfManufacture, decimal parPhonePrice)
        {
             _modelName = parModelName;
            _yearOfManufacture = parYearOfManufacture;
            _phonePrice = parPhonePrice;
            _phoneIdentifier = Guid.NewGuid();
        }


        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Phone() 
        {
            _phoneIdentifier = Guid.NewGuid();
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parPhone"></param>
        public Phone(Phone parPhone)
        {
            _modelName = parPhone.ModelName;
            _yearOfManufacture = parPhone.YearOfManufacture;
            _phonePrice = parPhone.PhonePrice;
            _phoneIdentifier = parPhone.PhoneIdentifier;
        }

        /// <summary>
        /// Виртуальный метод для вычисления скидки на телефон.
        /// </summary>
        /// <param name="parDiscountPercentage">Процент скидки.</param>
        /// <returns>Цена с учетом скидки.</returns>
        public virtual decimal CalculateDiscount(decimal parDiscountPercentage)
        {
            return PhonePrice - (PhonePrice * (parDiscountPercentage / 100));
        }


        /// <summary>
        /// Клонирование обьекта
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();
    }
}
