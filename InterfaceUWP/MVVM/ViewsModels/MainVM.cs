using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceUWP
{
    class MainVM : ViewModelBase
    {
      

        private string _titre = "Mon titre";

        public string Titre
        {
            get { return _titre; }
            set { 
                _titre = value;
               RaisePropertyChanged();
            }
        }
        private bool _isReadOnly;
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }

            set
            {
                _isReadOnly = value;
                RaisePropertyChanged();
            }
        }

    }
}
