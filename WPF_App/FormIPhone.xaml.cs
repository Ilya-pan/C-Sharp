using KPO_1;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPF_App
{
    /// <summary>
    /// Логика взаимодействия для FormIPhone.xaml
    /// </summary>
    public partial class FormIPhone : Window, IFormsInterfacerm
    {

        /// <summary>
        /// Телефон IPhone обрабатываемый на форме
        /// </summary>
        public IPhone IPhoneInner { get; set; }

        /// <summary>
        /// Телефон связанный с внешним объектом из DataGrid
        /// </summary>
        public IPhone IPhoneOther { get; set; }

        /// <summary>
        /// Конструктор формы дял работы с IPhone
        /// </summary>
        /// <param name="parIPhone">Обрабатываемый объект</param>
        /// <param name="parIsAllowEdit">Редактирование объекта на форме</param>
        /// <param name="parAction">Тип операции</param>
        public FormIPhone(IPhone parIPhone, bool parIsAllowEdit, FormAction parAction)
        {
            InitializeComponent();
            IPhoneInner = (IPhone)parIPhone.Clone();

            IPhoneOther = parIPhone;
            DataContext = IPhoneInner;
            Grid.IsEnabled = parIsAllowEdit;
            Title = ActionsManager.GetName(parAction);
            ButtonAction.Content = ActionsManager.GetName(parAction);

           
        }
        /// <summary>
        /// Получить телефон
        /// </summary>
        /// <returns>Телефон айфон</returns>
        public Phone GetPiece()
        {
            return IPhoneInner;
        }
        /// <summary>
        /// Открыть форму
        /// </summary>
        /// <returns>True, если форма успешно открыта</returns>
        public bool Open()
        {
            return (bool)ShowDialog();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Действие"
        /// </summary>
        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена"
        /// </summary>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Обработка для полей, принимающих числа с плавающей запятой
        /// </summary>
        private void PreviewTextInputFloat(object parSender, TextCompositionEventArgs parE)
        {
            parE.Handled = !CheckingValues.IsFloat(((TextBox)parSender).Text + parE.Text);
        }

        /// <summary>
        /// Обработка для полей, принимающих целочисленные значения
        /// </summary>
        private void PreviewTextInputInt(object parSender, TextCompositionEventArgs parE)
        {
            parE.Handled = !CheckingValues.IsInt(parE.Text);
        }
    }

}
