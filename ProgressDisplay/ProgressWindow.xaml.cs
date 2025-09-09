using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgressDisplay
{
    /// <summary>
    /// Логика взаимодействия для ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        /// <summary>
        /// Отменена ли генерация 
        /// </summary>
        private bool _isClosed = false;

        /// <summary>
        /// Поток генерации 
        /// </summary>
        private Thread _processor;

        /// <summary>
        /// Поток обработки отображения строки состояния
        /// </summary>
        private Thread _displayer;

        /// <summary>
        /// Текущее количество обработанных телефонов
        /// </summary>
        private int _currentAmountOfPhones;

        /// <summary>
        /// Количество телефонов для генерации
        /// </summary>
        private int _maxAmountOfPhones;

        /// <summary>
        /// Событие отмены генерации 
        /// </summary>
        public event Action CancelingProcessing;

        /// <summary>
        /// Событие закрытия формы генерации
        /// </summary>
        public event Action ClosingForm;

        /// <summary>
        /// Тип завершения работы с формой
        /// </summary>
        private byte _finishMod;

        /// <summary>
        /// Конструктор формы генерации сумок
        /// </summary>
        /// <param name="parLabelText">текст надписи над строкой состояния</param>
        /// <param name="parMaxPhone">количество телефонов для генерации</param>
        /// <param name="parFinish">тип закрытия формы</param>
        /// <param name="parAddingPhone">событие добавления телефона</param>
        public ProgressWindow(string parLabelText, int parMaxPhone, byte parFinish, Action parAddingPhone)
        {
            InitializeComponent();
            this.GenerationTextBlock.Text = parLabelText;
            _finishMod = parFinish;


            this.InitializationProgressBar.Value = 0;
            this.InitializationProgressBar.Minimum = 0;
            this.InitializationProgressBar.Maximum = parMaxPhone;

            _currentAmountOfPhones = 0;
            _maxAmountOfPhones = parMaxPhone;
            _processor = GetThreadGenerator(parAddingPhone);
            _displayer = GetThreadDisplayer();
        }

        /// <summary>
        /// Обновление строки состояния
        /// </summary>
        /// <param name="parCurrentAmountOfProcessedPhone">текущее количество обработанных телефонов</param>
        /// <param name="parLabel">текст для надпси над строкой состояния</param>
        /// <returns></returns>
        public bool UpdateProgressBar(int parCurrentAmountOfProcessedPhone = 1, string parLabel = "")
        {
            bool res = false;

            try
            {
                Dispatcher.Invoke(() =>
                {
                    this.GenerationTextBlock.Text = parLabel;
                    this.InitializationProgressBar.Value = parCurrentAmountOfProcessedPhone;

                    if (parCurrentAmountOfProcessedPhone == this.InitializationProgressBar.Maximum)
                    {
                        res = true;
                        if (_finishMod == 0)
                        {
                            this.CancelButton.Content = "Закрыть";
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                );

            }
            catch (Exception ex)
            {
                return true;
            }

            return res;
        }

        /// <summary>
        /// Получение потока генерации
        /// </summary>
        /// <param name="parAddingPhone"></param>
        /// <returns></returns>
        private Thread GetThreadGenerator(Action parAddingPhone)
        {
            return new Thread(() =>
            {
                int countSleeps = 0;
                int countForSleep = 300;

                while (!_isClosed && _currentAmountOfPhones < _maxAmountOfPhones)
                {
                    _currentAmountOfPhones++;
                    parAddingPhone();

                    if (countSleeps >= countForSleep)
                    {
                        countSleeps = 0;
                        Thread.Sleep(1);
                    }
                    else
                    {
                        countSleeps++;
                    }
                }
            }
              );
        }

        /// <summary>
        /// Получение потока обработки строки состояния
        /// </summary>
        /// <returns></returns>
        private Thread GetThreadDisplayer()
        {
            return new Thread(() =>
            {
                while (!_isClosed)
                {
                    _isClosed = UpdateProgressBar(_currentAmountOfPhones, $"Создано {_currentAmountOfPhones} / {_maxAmountOfPhones}");
                }
            });
        }

        /// <summary>
        /// Обработка нажатия на кнопку отмены генерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработка события закрытия окна генерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.CancelButton.IsEnabled = false;
            _isClosed = true;

            if (this.InitializationProgressBar.Value == this.InitializationProgressBar.Maximum)
            {
                ClosingForm?.Invoke();
            }
            else
            {
                CancelingProcessing?.Invoke();
            }
        }

        /// <summary>
        /// Обработка события загрузки окна генерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _processor?.Start();
            _displayer?.Start();
        }
    }
}

