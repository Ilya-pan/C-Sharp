using System;

namespace KPO_1
{
    /// <summary>
    /// Класс Смартфон, наследующий от базового класса Телефон.
    /// </summary>
    public abstract class Smartphone : Phone
    {
        /// <summary>
        /// Биометрические данные смартфона.
        /// </summary>
        private string _biometrics;

        /// <summary>
        /// Состояние разблокировки смартфона.
        /// </summary>
        private bool _isUnlocked;

        /// <summary>
        /// Биометрические данные смартфона.
        /// </summary>
        public string Biometrics
        {
            get { return _biometrics; }
            set { _biometrics = value; }
        }

        /// <summary>
        /// Состояние разблокировки смартфона.
        /// </summary>
        public bool IsUnlocked
        {
            get { return _isUnlocked; }
            set { _isUnlocked = value; }
        }

        /// <summary>
        /// Конструктор класса Smartphone.
        /// </summary>
        /// <param name="parModel">Модель смартфона.</param>
        /// <param name="parYear">Год выпуска смартфона.</param>
        /// <param name="parPrice">Цена смартфона.</param>
        /// <param name="parBiometrics">Биометрические данные смартфона.</param>
        public Smartphone(string parModel, int parYear, decimal parPrice, string parBiometrics, bool parIsUnlocked)
            : base(parModel, parYear, parPrice)
        {
            Biometrics = parBiometrics;
            IsUnlocked = parIsUnlocked; 
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Smartphone() { }

        /// <summary>
        /// Коснтруктор копирования
        /// </summary>
        /// <param name="parSmartphone"></param>
        public Smartphone(Smartphone parSmartphone) : base(parSmartphone)
        {
            _biometrics = parSmartphone.Biometrics;
            _isUnlocked = parSmartphone.IsUnlocked;
        }

        /// <summary>
        /// Метод для разблокировки смартфона по биометрическим данным.
        /// </summary>
        /// <param name="parBiometricData">Биометрические данные для разблокировки.</param>
        public void Unlock(string parBiometricData)
        {
            if (parBiometricData == Biometrics)
            {
                IsUnlocked = true;
            }
            else
            {
                IsUnlocked = false;
            }
        }

    }
}
