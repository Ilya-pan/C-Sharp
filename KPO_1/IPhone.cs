using System;

namespace KPO_1
{
    /// <summary>
    /// Класс IPhone, наследующий от класса Smartphone.
    /// </summary>
    public class IPhone : Smartphone
    {
        /// <summary>
        /// Приветствие Siri.
        /// </summary>
        private string _siriGreeting;

        /// <summary>
        /// Состояние включения Siri.
        /// </summary>
        private bool _siriEnabled;

        /// <summary>
        /// Приветствие Siri.
        /// </summary>
        public string SiriGreeting
        {
            get { return _siriGreeting; }
            set { _siriGreeting = value; }
        }

        /// <summary>
        /// Состояние включения Siri.
        /// </summary>
        public bool SiriEnabled
        {
            get { return _siriEnabled; }
            set { _siriEnabled = value; }
        }

        /// <summary>
        /// Конструктор класса IPhone.
        /// </summary>
        /// <param name="parModel">Модель iPhone.</param>
        /// <param name="parYear">Год выпуска iPhone.</param>
        /// <param name="parPrice">Цена iPhone.</param>
        /// <param name="parBiometrics">Биометрические данные iPhone.</param>
        /// <param name="parSiriGreeting">Приветствие Siri.</param>
        /// <param name="parSiriEnabled">Состояние включения Siri.</param>
        public IPhone(string parModel, int parYear, decimal parPrice, string parBiometrics, bool parIsUnlocked,
            string parSiriGreeting, bool parSiriEnabled)
            : base(parModel, parYear, parPrice, parBiometrics, parIsUnlocked)
        {
            PhoneIdentifier = Guid.NewGuid();
            SiriGreeting = parSiriGreeting;
            SiriEnabled = parSiriEnabled;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public IPhone() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parIPhone"></param>
        public IPhone (IPhone parIPhone): base(parIPhone)
        {
            _siriGreeting = parIPhone.SiriGreeting;
            _siriEnabled = parIPhone.SiriEnabled;
        }

        /// <summary>
        /// Метод для приветствия Siri с указанием имени пользователя и модели телефона.
        /// </summary>
        /// <param name="parName">Имя для приветствия.</param>
        /// <returns>Приветствие Siri с указанием имени пользователя и модели телефона, если Siri включена; иначе сообщение о том, что Siri не включена.</returns>
        public string GreetSiri(string parName)
        {
            if (SiriEnabled)
            {
                return $"{SiriGreeting}, {parName}! This is {ModelName}.";
            }
            else
            {
                return "Siri is not enabled.";
            }
        }


        /// <summary>
        /// Клонирование обьекта
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new IPhone(this);
        }
    }
}
