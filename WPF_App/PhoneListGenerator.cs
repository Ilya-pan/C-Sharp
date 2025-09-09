using KPO_1;
using ProgressDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPF_App
{
    /// <summary>
    /// Генератор списка телефонов
    /// </summary>
    internal class PhoneListGenerator
    {
        private static Random _random = new Random();

        /// <summary>
        /// Генерация случайного телефона
        /// </summary>
        private static Phone GenerateRandomPhone()
        {
            string model;
            int year = _random.Next(2000, 2025);
            decimal price = (decimal)_random.Next(50, 200000);
            bool hasTouchScreen = _random.Next(0, 2) == 1;

            int type = _random.Next(0, 4);
            switch (type)
            {
                case 0:
                    model = $"Android Phone {_random.Next(1, 10000)}";
                    return new AndroidPhone(
                        model,
                        year,
                        price,
                        hasTouchScreen ? "Сканер лица" : "Отпечаток пальца",
                        hasTouchScreen,
                        DateTime.Now.AddMonths(-_random.Next(1, 12)),
                        _random.Next(0, 2) == 1);

                case 1:
                    model = $"iPhone {_random.Next(1, 20)}";
                    return new IPhone(
                        model,
                        year,
                        price,
                        "Face ID",
                        hasTouchScreen,
                        "Привет, как я могу помочь?",
                        _random.Next(0, 2) == 1);

                case 2:
                    model = $"CandyBar {_random.Next(1, 10000)}";
                    return new CandyBarPhone(
                        model,
                        year,
                        price,
                        hasTouchScreen,
                        _random.Next(0, 2) == 1,
                        _random.Next(5, 15));

                case 3:
                    model = $"Clamshell {_random.Next(1, 10000)}";
                    return new ClamshellPhone(
                        model,
                        year,
                        price,
                        hasTouchScreen,
                        _random.Next(0, 2) == 1,
                        _random.Next(0, 2) == 1,
                        _random.Next(100, 200));
            }

            return null;
        }

        /// <summary>
        /// Генерация списка случайных телефонов
        /// <param name="parMaxBag">Количество телефонов для генерации</param>
        /// <param name="parFinish">Тип закрытия формы генерации списка телефонов</param>
        /// </summary>
        public static List<Phone> GetPhonesList(int parMaxPhone, byte parFinish)
        {
            List<Phone> res = new List<Phone>();

            ProgressWindow dataGenerator = new ProgressWindow("", parMaxPhone, parFinish, () => res.Add(GenerateRandomPhone()));
            dataGenerator.CancelingProcessing += () => res.Clear();
            dataGenerator.ShowDialog();
            return res;
        }
    }
}
