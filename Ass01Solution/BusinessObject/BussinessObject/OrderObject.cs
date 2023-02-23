using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs
{
    public class OrderObject : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    _orderId = value;
                    OnPropertyChanged(nameof(OrderId));
                }
            }
        }

        private int _memberId;
        public int MemberId
        {
            get { return _memberId; }
            set
            {
                if (_memberId != value)
                {
                    _memberId = value;
                    OnPropertyChanged(nameof(MemberId));
                }
            }
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                if (_orderDate != value)
                {
                    _orderDate = value;
                    OnPropertyChanged(nameof(OrderDate));
                }
            }
        }

        private DateTime _requiredDate;
        public DateTime RequiredDate
        {
            get { return _requiredDate; }
            set
            {
                if (_requiredDate != value)
                {
                    _requiredDate = value;
                    OnPropertyChanged(nameof(RequiredDate));
                }
            }
        }

        private DateTime _shippedDate;
        public DateTime ShippedDate
        {
            get { return _shippedDate; }
            set
            {
                if (_shippedDate != value)
                {
                    _shippedDate = value;
                    OnPropertyChanged(nameof(ShippedDate));
                }
            }
        }

        private decimal _freight;
        public decimal Freight
        {
            get { return _freight; }
            set
            {
                if (_freight != value)
                {
                    _freight = value;
                    OnPropertyChanged(nameof(Freight));
                }
            }
        }

        private MemberObject _member;
        public MemberObject Member
        {
            get { return _member; }
            set
            {
                if (_member != value)
                {
                    _member = value;
                    OnPropertyChanged(nameof(Member));
                }
            }
        }

    }
}
