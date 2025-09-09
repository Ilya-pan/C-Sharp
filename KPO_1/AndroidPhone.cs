using System;

namespace KPO_1
{
    /// <summary>
    /// Класс AndroidPhone, наследующий от класса Smartphone.
    /// </summary>
    public class AndroidPhone : Smartphone
    {

        /// <summary>
        /// Дата прошивки Android-телефона.
        /// </summary>
        private DateTime _firmwareDate;

        /// <summary>
        /// Состояние root-прав на Android-телефоне.
        /// </summary>
        private bool _rootEnabled;

        /// <summary>
        /// Дата прошивки Android-телефона.
        /// </summary>
        public DateTime FirmwareDate
        {
            get { return _firmwareDate; }
            set { _firmwareDate = value; }
        }

        /// <summary>
        /// Состояние root-прав на Android-телефоне.
        /// </summary>
        public bool RootEnabled
        {
            get { return _rootEnabled; }
            set { _rootEnabled = value; }
        }

        /// <summary>
        /// Конструктор класса AndroidPhone.
        /// </summary>
        /// <param name="parModel">Модель Android-телефона.</param>
        /// <param name="parYear">Год выпуска Android-телефона.</param>
        /// <param name="parPrice">Цена Android-телефона.</param>
        /// <param name="parBiometrics">Биометрические данные Android-телефона.</param>
        /// <param name="parFirmwareDate">Дата прошивки Android-телефона.</param>
        /// <param name="parRootEnabled">Состояние root-прав на Android-телефоне.</param>
        public AndroidPhone(string parModel, int parYear, decimal parPrice, string parBiometrics, bool parIsUnlocked,
            DateTime parFirmwareDate, bool parRootEnabled)
            : base(parModel, parYear, parPrice, parBiometrics, parIsUnlocked)
        {
            PhoneIdentifier = Guid.NewGuid();
            FirmwareDate = parFirmwareDate;
            RootEnabled = parRootEnabled;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public AndroidPhone() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parIPhone"></param>
        public AndroidPhone(AndroidPhone parAndroidPhone) : base(parAndroidPhone)
        {
            _firmwareDate = ((AndroidPhone)parAndroidPhone).FirmwareDate;
            _rootEnabled = ((AndroidPhone)parAndroidPhone).RootEnabled;
        }

        /// <summary>
        /// Метод для копирования прошивки на Android-телефоне с указанием даты прошивки.
        /// </summary>
        /// <param name="parNewFirmwareDate">Новая дата прошивки.</param>
        /// <returns>True, если прошивка успешно скопирована; иначе false.</returns>
        public bool CopyFirmware( DateTime parNewFirmwareDate)
        {
            if (RootEnabled && parNewFirmwareDate > FirmwareDate)
            {
                FirmwareDate = parNewFirmwareDate;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Клонирование обьекта
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new AndroidPhone(this);
        }
    }
}
