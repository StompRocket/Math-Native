using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Eto.Forms;

namespace StompRocket.Math
{
    public class ListModel : INotifyPropertyChanged
    {
        private ListItemCollection listItems = new ListItemCollection();

        public ListItemCollection Items
        {
            get { return listItems; }
            set
            {
                if (listItems != value)
                {
                    listItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public void Add(string value)
        {
            listItems.Add(value);
            OnPropertyChanged();
        }

        public ListModel()
        {
        }

        void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
