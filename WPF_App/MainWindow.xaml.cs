using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using KPO_1;
using PhonesPattern.Factory;
using PhonesPattern.MethodFactory;




namespace WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Телефоны
        /// </summary>
        private ObservableCollection<Phone> _phones = new ObservableCollection<Phone>();

        /// <summary>
        /// Фабрики
        /// </summary>
        private ObservableCollection<IFactoryPhone> _factories = new ObservableCollection<IFactoryPhone>();

        /// <summary>
        /// Фабричный метод для андроида и моноблочного телефона
        /// </summary>
        private AndroidAndCandyBarPhoneFactoryMethod _androidAndCandyBarPhoneFactoryMethod = new AndroidAndCandyBarPhoneFactoryMethod();

        /// <summary>
        /// Фабричный метод для айфона и телефон-раскладушка
        /// </summary>
        private IPhoneAndClamshellPhoneMethod _iPhoneAndClamshellPhoneMethod = new IPhoneAndClamshellPhoneMethod();

        /// <summary>
        /// Фабричный метод для прототипов
        /// </summary>
        private PrototypeFactoryMethod _prototypeFactoryMethod;

        /// <summary>
        /// Список  телефонов
        /// </summary>
        public ObservableCollection<Phone> Phones
        {
            get { return _phones; }
            set { _phones = value; }
        }

        /// <summary>
        /// Конструктор главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataGridPhones.ItemsSource = Phones;
            ComboBoxFactory.ItemsSource = _factories;
            NumberFilterTypeComboBox.ItemsSource = new List<string> { "Точное соответствие", "В пределах значений" };
            NumberFilterTypeComboBox.SelectedIndex = 1;
            InitializeFactories();
        }
  
        /// <summary>
        /// Получить форму для заданного телефона и действия
        /// </summary>
        /// <param name="parPiece">Телефон</param>
        /// <param name="parAction">Действие</param>
        /// <returns>Форма для редактирования растения</returns>
        private IFormsInterfacerm GetForm(Phone parPiece, FormAction parAction)
        {
            IFormsInterfacerm form = null;
            switch (parPiece)
            {
                case AndroidPhone androidphone:
                    form = new FormAndroidPhone(androidphone, ActionsManager.IsAllowEdit(parAction), parAction);
                    break;
                case IPhone iphone:
                    form = new FormIPhone(iphone, ActionsManager.IsAllowEdit(parAction), parAction);
                    break;
                case CandyBarPhone candybarphone:
                    form = new FormCandyBarPhone(candybarphone, ActionsManager.IsAllowEdit(parAction), parAction);
                    break;
                case ClamshellPhone clamshellphone:
                    form = new FormClamshellPhone(clamshellphone, ActionsManager.IsAllowEdit(parAction), parAction);
                    break;
            }
            return form;
        }

        /// <summary>
        /// Выполнить действие с телефоном
        /// </summary>
        /// <param name="parPiece">Телефон</param>
        /// <param name="parAction">Действие</param>
        private void Execute(Phone parPiece, FormAction parAction)
        {
            if (parPiece == null) return;
            IFormsInterfacerm form = GetForm(parPiece, parAction);
            if (form.Open())
            {
                switch (parAction)
                {
                    case FormAction.Create:
                        Phones.Add(form.GetPiece());
                        DataGridPhones.SelectedItem = form.GetPiece();
                        break;
                    case FormAction.CreatePrototype:
                        Phones.Add(form.GetPiece());
                        break;
                    case FormAction.Remove:
                        Phones.Remove(parPiece);
                        break;
                    case FormAction.Edit:
                        parPiece = (Phone)form.GetPiece().Clone();
                        break;
                }
            }
        }

        /// <summary>
        /// Удалить выбранный телефон
        /// </summary>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Execute((Phone)DataGridPhones.SelectedItem, FormAction.Remove);
        }

        /// <summary>
        /// Редактировать выбранный телефон
        /// </summary>
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Execute((Phone)DataGridPhones.SelectedItem, FormAction.Edit);
            DataGridPhones.Items.Refresh();
        }
 
        /// <summary>
        /// Добавить телефон андроид
        /// </summary>
        private void ButtonAddAndroid_Click(object sender, RoutedEventArgs e)
        {
            Execute(new AndroidPhone(), FormAction.Create);
        }

        /// <summary>
        /// Добавить телефон айфон
        /// </summary>
        private void ButtonAddIPhone_Click(object sender, RoutedEventArgs e)
        {
            Execute(new IPhone(), FormAction.Create);
        }

        /// <summary>
        /// Добавить телефон моноблочный
        /// </summary>
        private void ButtonAddCandyBar_Click(object sender, RoutedEventArgs e)
        {
            Execute(new CandyBarPhone(), FormAction.Create);
        }

        /// <summary>
        /// Добавить телефон раскладушка
        /// </summary>
        private void ButtonAddClamshell_Click(object sender, RoutedEventArgs e)
        {
            Execute(new ClamshellPhone(), FormAction.Create);
        }

        /// <summary>
        /// Добавить случайные телефоны
        /// </summary>
        /* private void ButtonRandomValues_Click(object sender, RoutedEventArgs e)
         {
             _phones.Clear();
             AndroidPhone androidPhone1 = new AndroidPhone("Samsung Galaxy S24 Ultra", 2023, 106990, "Отпечаток пальца",true, new DateTime(2023, 2, 1), true);
             AndroidPhone androidPhone2 = new AndroidPhone("Google Pixel 7", 2023, 89990, "Сканер лица", false, new DateTime(2023, 5, 15), false);
             AndroidPhone androidPhone3 = new AndroidPhone("OnePlus 12 Pro", 2024, 119990, "Сканер радужки", true, new DateTime(2024, 4, 4), false);
             IPhone iPhone1 = new IPhone("iPhone 14 Pro", 2023, 150000, "Face ID", true, "Привет, как я могу помочь?", true);
             IPhone iPhone2 = new IPhone("iPhone 14", 2024, 130000, "Face ID", true, "Привет, пользователь,как я могу помочь?", true);
             IPhone iPhone3 = new IPhone("iPhone 16", 2024, 180000, "Face ID", true, "Здравствуйте, чем могу помочь?", true);
             CandyBarPhone candyBarPhone1 = new CandyBarPhone("Nokia 3310", 2000, (decimal)45.67, true, true, 10.5);
             CandyBarPhone candyBarPhone2 = new CandyBarPhone("Motorola RAZR V3", 2004, (decimal)199.99,true, false, 8.0);
             CandyBarPhone candyBarPhone3 = new CandyBarPhone("Sony Ericsson T68i", 2002, (decimal)149.99,true, true, 9.2);
             ClamshellPhone clamshellPhone1 = new ClamshellPhone("Motorola RAZR", 2005, (decimal)299.99, true, false, false, 120);
             ClamshellPhone clamshellPhone2 = new ClamshellPhone("Samsung Galaxy Z Flip", 2020, (decimal)999.99, false, true, true, 180);
             ClamshellPhone clamshellPhone3 = new ClamshellPhone("Nokia 2720 Flip", 2019, (decimal)129.99, true, true, false, 145);

             Phones.Add(androidPhone1);
             Phones.Add(androidPhone2);
             Phones.Add(androidPhone3);
             Phones.Add(iPhone1);
             Phones.Add(iPhone2);
             Phones.Add(iPhone3);
             Phones.Add(candyBarPhone1);
             Phones.Add(candyBarPhone2);
             Phones.Add(candyBarPhone3);
             Phones.Add(clamshellPhone1);
             Phones.Add(clamshellPhone2);
             Phones.Add(clamshellPhone3);
             DataGridPhones.Items.Refresh();
         }*/

        /// <summary>
        /// Генерация некотрых записей для DataGridBags
        /// </summary>
        private void ButtonRandomValues_Click(object parSender, RoutedEventArgs parE)
        {
            DataGridPhones.Items.Refresh();

            int countRecords = int.Parse(this.AmountOfPhonesTextBox.Text);

            if (countRecords == 0)
            {
                return;
            }

            byte finish = 0;
            if (this.FinishModCheckBox.IsChecked == true) finish = 1;

            List<Phone> phoneList = PhoneListGenerator.GetPhonesList(countRecords, finish);

            if (phoneList.Count > 0)
            {
                _phones = new ObservableCollection<Phone>(phoneList);
                this.DataGridPhones.ItemsSource = _phones;
            }

            this.DataGridPhones.Items.Refresh();
        }

        /// <summary>
        /// Добавление обычного телефона 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddAndroidAndCandyBarPhone_Click(object sender, RoutedEventArgs e)
        {
            Smartphone smartphone = ((IFactoryPhone)ComboBoxFactory.SelectedItem).CreateSmartphone();
            Execute(smartphone, FormAction.Create);
        }

        /// <summary>
        /// Добавление смартфона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddIPhoneAndClamshellPhone_Click(object sender, RoutedEventArgs e)
        {
            FeaturePhone featurePhone = ((IFactoryPhone)ComboBoxFactory.SelectedItem).CreateFeaturePhone();
            Execute(featurePhone, FormAction.Create);
        }

        /// <summary>
        /// Инициализация фабрик
        /// </summary>
        private void InitializeFactories()
        {
            _factories.Add(_androidAndCandyBarPhoneFactoryMethod.CreateFactory());
            _factories.Add(_iPhoneAndClamshellPhoneMethod.CreateFactory());
            InitializPrototype();
            _factories.Add(_prototypeFactoryMethod.CreateFactory());
        }

        /// <summary>
        /// Инициализация прототипа
        /// </summary>
        private void InitializPrototype()
        {
            Execute(new IPhone(), FormAction.CreatePrototype);
            Execute(new CandyBarPhone(), FormAction.CreatePrototype);
            _prototypeFactoryMethod = new PrototypeFactoryMethod((Smartphone)_phones[0], (FeaturePhone)_phones[1]);
            _phones.Clear();
        }

        /// <summary>
        /// Обработка события смены типа фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberFilterTypeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (this.NumberFilterTypeComboBox.SelectedIndex == 0)
            {
                this.MinLabel.Content = "=";
                this.MaxLabel.Content = "";
                this.MaxLabel.IsEnabled = false;
                this.MaxNumberFilter_TextBox.IsEnabled = false;
            }
            else
            {
                this.MinLabel.Content = "От";
                this.MaxLabel.Content = "До";
                this.MaxLabel.IsEnabled = true;
                this.MaxNumberFilter_TextBox.IsEnabled = true;
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            Phone? selectedBag = DataGridPhones.SelectedItem as Phone;

            CollectionViewSource collectionViewSource = new CollectionViewSource() { Source = _phones };
            FilterExpander.Header = "Фильтрация ";

            if (!string.IsNullOrEmpty(this.TextFilter_TextBox.Text))
            {
                collectionViewSource.Filter += new FilterEventHandler(FilterPhoneName);
                FilterExpander.Header += "по слову '" + this.TextFilter_TextBox.Text + "' ";

            }
            if (this.NumberFilterTypeComboBox.SelectedIndex == 0 && !string.IsNullOrEmpty(this.MinNumberFilter_TextBox.Text))
            {
                decimal eps = 0.001M;
                decimal tmpValue = decimal.Parse(MinNumberFilter_TextBox.Text);
                decimal min = tmpValue - eps;
                decimal max = tmpValue + eps;

                collectionViewSource.Filter += (sender, e) => FilterInRange(sender, e, min, max);
                FilterExpander.Header += " по цене Price = " + this.MinNumberFilter_TextBox.Text + " ";
            }
            if (this.NumberFilterTypeComboBox.SelectedIndex == 1 && (!string.IsNullOrEmpty(this.MinNumberFilter_TextBox.Text) || !string.IsNullOrEmpty(this.MaxNumberFilter_TextBox.Text)))
            {
                decimal min = string.IsNullOrEmpty(MinNumberFilter_TextBox.Text) ? decimal.MinValue : decimal.Parse(MinNumberFilter_TextBox.Text);
                decimal max = string.IsNullOrEmpty(MaxNumberFilter_TextBox.Text) ? decimal.MaxValue : decimal.Parse(MaxNumberFilter_TextBox.Text);

                collectionViewSource.Filter += (sender, e) => FilterInRange(sender, e, min, max);

                FilterExpander.Header += " по цене Price от " + MinNumberFilter_TextBox.Text + " и до " + this.MaxNumberFilter_TextBox.Text + " ";
            }

            ICollectionView collectionView = collectionViewSource.View;

            this.DataGridPhones.ItemsSource = collectionView;
            this.DataGridPhones.SelectedItem = selectedBag;
        }

        /// <summary>
        /// Фильтрация списка телефонов по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterPhoneName(object sender, FilterEventArgs e)
        {
            var obj = e.Item as Phone;
            if (obj != null)
            {
                if (obj.ModelName.Contains(this.TextFilter_TextBox.Text))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        /// <summary>
        /// Фильтрация списка сумок по цене в пределах значений parMin и parMax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="parMin">Левая граница интервала</param>
        /// <param name="parMax">Правая граница интервала</param>
        private void FilterInRange(object sender, FilterEventArgs e, decimal parMin, decimal parMax)
        {
            var obj = e.Item as Phone;

            if (obj != null)
            {
                if (obj.PhonePrice >= parMin && obj.PhonePrice <= parMax && obj.ModelName.Contains(TextFilter_TextBox.Text))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку сброса фильтров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetFilter_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataGridPhones.ItemsSource = _phones;
            this.TextFilter_TextBox.Text = "";
            this.MaxNumberFilter_TextBox.Text = "";
            this.MinNumberFilter_TextBox.Text = "";
            FilterExpander.Header = "Фильтрация ";
        }

        /// <summary>
        /// Обработка события ввода текста в поле ввода MinTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!this.MinNumberFilter_TextBox.Text.Contains(".") && this.MinNumberFilter_TextBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработка события ввода текста в поле ввода MaxTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!this.MaxNumberFilter_TextBox.Text.Contains(".") && this.MaxNumberFilter_TextBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}