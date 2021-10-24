using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HW3
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Phone _selectedPhone;
        private ICommand _addCommand;
        private ICommand _removeCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Phone> Phones { get; set; }


        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title="iPhone 7", Company="Apple", Price=56000 },
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Phone {Title="Elite x3", Company="HP", Price=56000 },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };
        }

        public ICommand AddElementCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand(obj =>
                {
                    Phone phone = new Phone();
                    Phones.Insert(0, phone);
                    SelectedPhone = phone;
                });
            }
        }

        public ICommand RemoveElementCommand
        {
            get
            {
                return _removeCommand ??= new RelayCommand(obj =>
                {
                    Phones.Remove(_selectedPhone);
                });
            }
        }

        public Phone SelectedPhone
        {
            get => _selectedPhone;
            set
            {
                _selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
