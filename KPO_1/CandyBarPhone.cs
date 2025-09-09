using System;

namespace KPO_1
{
    /// <summary>
    /// Класс CandyBarPhone, наследующий от класса FeaturePhone.
    /// </summary>
    public class CandyBarPhone : FeaturePhone
    {
        /// <summary>
        /// Радиус действия антенны на телефоне.
        /// </summary>
        private double _antennaCoverageRadius;

        /// <summary>
        /// Радиус действия антенны на телефоне.
        /// </summary>
        public double AntennaCoverageRadius
        {
            get { return _antennaCoverageRadius; }
            set { _antennaCoverageRadius = value; }
        }

        /// <summary>
        /// Конструктор класса CandyBarPhone.
        /// </summary>
        /// <param name="parModel">Модель телефона.</param>
        /// <param name="parYear">Год выпуска телефона.</param>
        /// <param name="parPrice">Цена телефона.</param>
        /// <param name="parInfraredPort">Наличие инфракрасного порта.</param>
        /// <param name="parAntennaCoverageRadius">Радиус действия антенны.</param>
        public CandyBarPhone(string parModel, int parYear, decimal parPrice, bool parInfraredPort, bool parIsFileSent,
            double parAntennaCoverageRadius)
            : base(parModel, parYear, parPrice, parInfraredPort, parIsFileSent)
        {
            PhoneIdentifier = Guid.NewGuid();
            AntennaCoverageRadius = parAntennaCoverageRadius;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public CandyBarPhone() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parSpruce"></param>
        public CandyBarPhone(CandyBarPhone parCandyBarPhone) : base(parCandyBarPhone)
        {
            _antennaCoverageRadius = parCandyBarPhone.AntennaCoverageRadius;
        }

        /// <summary>
        /// Метод для отправки сообщения объекту, находящемуся вблизи.
        /// </summary>
        /// <param name="parDistanceToObject">Расстояние до объекта.</param>
        /// <param name="parMessage">Текст сообщения.</param>
        /// <param name="parRecipient">Адресат сообщения.</param>
        /// <returns>Информация о сообщении, которое было отправлено.</returns>
        public string SendMessageToNearbyObject(double parDistanceToObject, string parMessage, string parRecipient)
        {
            // Логика отправки сообщения объекту, находящемуся вблизи
            if (AntennaCoverageRadius >= parDistanceToObject)
            {
                return $"Сообщение: \"{parMessage}\" отправлено  {parRecipient} от {ModelName}";
            }
            else
            {
                return "Нет объектов в радиусе действия антенны.";
            }
        }


        /// <summary>
        /// Клонирование обьекта
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new CandyBarPhone(this);
        }
    }
}
