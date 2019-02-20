using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Test123
{
    class Main : INotifyPropertyChanged
    {
        private int _age;
        private string _goroscop;
        private DateTime _date;
        private readonly string[] _zodiaks = new string[]
        {
            "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза",
            "Мавпа", "Півень", "Собака", "Свиня"
        };

        public int Age
        {
            get { return _age; }
        }

        public string Goroscop
        {
            get { return _goroscop; }
        }
        public DateTime GetDate
        {

            set
            {
                _date = value;
                CountAge();
                CreateGoroscop();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(Goroscop));
                OnPropertyChanged();
            }
        }

        private void CountAge()
        {
            _age = (DateTime.Today - _date).Days / 365;
            if (_age > 135) MessageBox.Show("Помилка! Ваш вік не може перевищувати 135 років");
            else if (_date > DateTime.Today) MessageBox.Show("Помилка! Ви ще не народились:(");
            else if (_date == DateTime.Today) MessageBox.Show("З Днем Народження!");

        }

        private void CreateGoroscop()
        {
          _goroscop = _zodiaks[(_date.Year - 4) % 12];
        }

    #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
