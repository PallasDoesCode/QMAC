using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QMAC.ViewModels
{
    class ViewModelBase<T> : INotifyPropertyChanged
    {
        /*
         * http://perezgb.com/2010/01/02/mvvm-multiselect-listbox
         * 
         * /

        private bool isSelected;
        private T item;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler SelectionChanged;

        /*
         *  This property was created for use with ListViews. It's primary
         *  purpose is to help aid in the creation of a databinding that allows
         *  for multiple selections in a ListView.
         */
        public bool IsSelected
        {
            get { return IsSelected; }
            set
            {
                if (value == isSelected)
                {
                    return;
                }

                isSelected = value;
                OnPropertyChanged("isSelected");
                OnSelectionChanged();
            }
        }

        /*
         *  This property was also created for use with ListViews. It's primary
         *  purpose is to help aid in the creation of a databinding that allows
         *  for multiple selections in a ListView.
         */
        public T Item
        {
            get { return Item; }
            set
            {
                if (value.Equals(item))
                {
                    return;
                }

                item = value;
                OnPropertyChanged("Item");
            }
        }

        /*
         *  This constructor was created for use with ListViews. It's primary
         *  purpose is to help aid in the creation of a databinding that allows
         *  for multiple selections in a ListView.
         */
        public ViewModelBase(T item)
            : this(false, item)
        {
        }

        /*
         *  This constructor was also created for use with ListViews. It's primary
         *  purpose is to help aid in the creation of a databinding that allows
         *  for multiple selections in a ListView.
         */
        public ViewModelBase(bool selected, T item)
        {
            this.isSelected = selected;
            this.item = item;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        protected virtual void OnSelectionChanged()
        {
            EventHandler changed = SelectionChanged;
            if (changed != null)
            {
                changed(this, EventArgs.Empty);
            }
        }
    }
}
