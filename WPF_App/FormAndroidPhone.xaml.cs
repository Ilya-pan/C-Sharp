using KPO_1;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_App
{
    /// <summary>
    /// Логика взаимодействия для FormAndroidPhone.xaml
    /// </summary>
    public partial class FormAndroidPhone : Window, IFormsInterfacerm
    {
        /// <summary>
        /// Телефон AndroidPhone обрабатываемый на форме
        /// </summary>
        public AndroidPhone AndroidPhoneInner { get; set; }

        /// <summary>
        /// Телефон связанный с внешним объектом из DataGrid
        /// </summary>
        public AndroidPhone AndroidPhoneOther { get; set; }

        /// <summary>
        /// Конструктор формы дял работы с AndroidPhone
        /// </summary>
        /// <param name="parAndroidPhone">Обрабатываемый объект</param>
        /// <param name="parIsAllowEdit">Редактирование объекта на форме</param>
        /// <param name="parAction">Тип операции</param>
        public FormAndroidPhone(AndroidPhone parAndroidPhone, bool parIsAllowEdit, FormAction parAction)
        {
            InitializeComponent();
            AndroidPhoneInner = (AndroidPhone)parAndroidPhone.Clone();
            AndroidPhoneOther = parAndroidPhone;
            DataContext = AndroidPhoneInner;
            Grid.IsEnabled = parIsAllowEdit;
            Title = ActionsManager.GetName(parAction);
            ButtonAction.Content = ActionsManager.GetName(parAction);
        }

        /// <summary>
        /// Получить телефон
        /// </summary>
        /// <returns>Телефон Андроид</returns>
        public  Phone GetPiece()
        {
            return AndroidPhoneInner;
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
