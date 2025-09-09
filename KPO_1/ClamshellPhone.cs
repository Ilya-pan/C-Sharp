using System;

namespace KPO_1
{
    /// <summary>
    /// Класс ClamshellPhone, наследующий от класса FeaturePhone.
    /// </summary>
    public class ClamshellPhone : FeaturePhone
    {
        /// <summary>
        /// Состояние открытости телефона.
        /// </summary>
        private bool _isOpen;

        /// <summary>
        /// Угол открытия телефона.
        /// </summary>
        private double _openingAngle;

        /// <summary>
        /// Состояние открытости телефона.
        /// </summary>
        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; }
        }

        /// <summary>
        /// Угол открытия телефона.
        /// </summary>
        public double OpeningAngle
        {
            get { return _openingAngle; }
            set { _openingAngle = value; }
        }

        /// <summary>
        /// Конструктор класса ClamshellPhone.
        /// </summary>
        /// <param name="parModel">Модель телефона.</param>
        /// <param name="parYear">Год выпуска телефона.</param>
        /// <param name="parPrice">Цена телефона.</param>
        /// <param name="parInfraredPort">Наличие инфракрасного порта.</param>
        /// <param name="parIsOpen">Состояние открытости телефона.</param>
        /// <param name="parOpeningAngle">Угол открытия телефона.</param>
        public ClamshellPhone(string parModel, int parYear, decimal parPrice, bool parInfraredPort, bool parIsFileSent,
            bool parIsOpen, double parOpeningAngle)
            : base(parModel, parYear, parPrice, parInfraredPort, parIsFileSent)
        {
            PhoneIdentifier = Guid.NewGuid();
            IsOpen = parIsOpen;
            OpeningAngle = parOpeningAngle;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ClamshellPhone() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parClamshellPhone"></param>
        public ClamshellPhone(ClamshellPhone parClamshellPhone) : base(parClamshellPhone)
        {
            _isOpen = parClamshellPhone.IsOpen;
            _openingAngle = parClamshellPhone.OpeningAngle;
        }

        /// <summary>
        /// Метод для открытия или закрытия телефона с учетом угла открытия.
        /// </summary>
        /// <param name="parOpeningAngle">Угол открытия телефона.</param>
        /// <returns>Строка с информацией о состоянии телефона после открытия или закрытия.</returns>
        public string OpenClose(double parOpeningAngle)
        {
            if (parOpeningAngle < 0 || parOpeningAngle > 180)
            {
                return "Некорректный угол открытия.";
            }

            if (parOpeningAngle >= 90)
            {
                IsOpen = true;
                OpeningAngle = parOpeningAngle;
                return $"Телефон открыт на углу {parOpeningAngle} градусов.";
            }
            else
            {
                IsOpen = false;
                OpeningAngle = parOpeningAngle;
                return $"Телефон закрыт на угл {parOpeningAngle} градусов.";
            }
        }


        /// <summary>
        /// Клонирование обьекта
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new ClamshellPhone(this);
        }
    }
}
