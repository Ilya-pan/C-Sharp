using System;

namespace KPO_1
{
    /// <summary>
    /// Класс FeaturePhone, наследующий от базового класса Телефон.
    /// </summary>
    public abstract class FeaturePhone : Phone
    {
        /// <summary>
        /// Наличие инфракрасного порта на телефоне.
        /// </summary>
        private bool _infraredPort;

        /// <summary>
        /// Статус отправки файла через инфракрасный порт.
        /// </summary>
        private bool _isFileSent;

        // Свойства класса

        /// <summary>
        /// Наличие инфракрасного порта на телефоне.
        /// </summary>
        public bool InfraredPort
        {
            get { return _infraredPort; }
            set { _infraredPort = value; }
        }

        /// <summary>
        /// Статус отправки файла через инфракрасный порт.
        /// </summary>
        public bool IsFileSent
        {
            get { return _isFileSent; }
            set { _isFileSent = value; }
        }

        /// <summary>
        /// Конструктор класса FeaturePhone.
        /// </summary>
        /// <param name="parModel">Модель телефона.</param>
        /// <param name="parYear">Год выпуска телефона.</param>
        /// <param name="parPrice">Цена телефона.</param>
        /// <param name="parUniqueIdentifier">Уникальный идентификатор телефона.</param>
        /// <param name="parInfraredPort">Наличие инфракрасного порта.</param>
        public FeaturePhone(string parModel, int parYear, decimal parPrice, bool parInfraredPort, bool parIsFileSent)
            : base(parModel, parYear, parPrice)
        {
            InfraredPort = parInfraredPort;
            IsFileSent = parIsFileSent;
        }


        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FeaturePhone() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parFeaturePhone"></param>
        public FeaturePhone(FeaturePhone parFeaturePhone) : base(parFeaturePhone)
        {
            _infraredPort = parFeaturePhone.InfraredPort;
            _isFileSent = parFeaturePhone.IsFileSent;
        }

        /// <summary>
        /// Метод для отправки файла через инфракрасный порт.
        /// </summary>
        public void SendFile()
        {
            if (InfraredPort)
            {
                _isFileSent = true;
            }
            else
            {
                _isFileSent = false;
            }
        }

    }
}
