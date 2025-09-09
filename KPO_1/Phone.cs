using System.Security.Cryptography;
using System.Xml;

namespace KPO_1
{
    /// <summary>
    /// ������� ����� ��� ������������� ��������.
    /// </summary>
    public abstract class Phone
    {
        // ������ ��������.
        private string _modelName;

        // ��� ������� ��������.
        private int _yearOfManufacture;

        // ���� ��������.
        private decimal _phonePrice;

        // ���������� ������������� ��������.
        private Guid _phoneIdentifier;

        /// <summary>
        /// ������ ��������.
        /// </summary>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// <summary>
        /// ��� ������� ��������.
        /// </summary>
        public int YearOfManufacture
        {
            get { return _yearOfManufacture; }
            set { _yearOfManufacture = value; }
        }

        /// <summary>
        /// ���� ��������.
        /// </summary>
        public decimal PhonePrice
        {
            get { return _phonePrice; }
            set { _phonePrice = value; }
        }

        /// <summary>
        /// ���������� ������������� ��������.
        /// </summary>
        public Guid PhoneIdentifier
        {
            get { return _phoneIdentifier; }
            set { _phoneIdentifier = value; }
        }

        /// <summary>
        /// ����������� ������ Phone.
        /// </summary>
        /// <param name="parModelName">������ ��������.</param>
        /// <param name="parYearOfManufacture">��� ������� ��������.</param>
        /// <param name="parPhonePrice">���� ��������.</param>
        public Phone(string parModelName, int parYearOfManufacture, decimal parPhonePrice)
        {
             _modelName = parModelName;
            _yearOfManufacture = parYearOfManufacture;
            _phonePrice = parPhonePrice;
            _phoneIdentifier = Guid.NewGuid();
        }


        /// <summary>
        /// ������ �����������
        /// </summary>
        public Phone() 
        {
            _phoneIdentifier = Guid.NewGuid();
        }

        /// <summary>
        /// ����������� �����������
        /// </summary>
        /// <param name="parPhone"></param>
        public Phone(Phone parPhone)
        {
            _modelName = parPhone.ModelName;
            _yearOfManufacture = parPhone.YearOfManufacture;
            _phonePrice = parPhone.PhonePrice;
            _phoneIdentifier = parPhone.PhoneIdentifier;
        }

        /// <summary>
        /// ����������� ����� ��� ���������� ������ �� �������.
        /// </summary>
        /// <param name="parDiscountPercentage">������� ������.</param>
        /// <returns>���� � ������ ������.</returns>
        public virtual decimal CalculateDiscount(decimal parDiscountPercentage)
        {
            return PhonePrice - (PhonePrice * (parDiscountPercentage / 100));
        }


        /// <summary>
        /// ������������ �������
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();
    }
}
