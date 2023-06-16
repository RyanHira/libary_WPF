using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bieb.Models
{
    public class Author : NotifyPropertyChanged
    {

        //Verkrijg data en waarden
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChange(); // Laat viewmodel weten voor veranderingen
            }
        }


        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChange(); // Laat viewmodel weten voor veranderingen
			}
        }
        // De collectie van BiebItems geralteerd met de author
        public ObservableCollection<BiebItem> BiebItems { get; set; }
        
    }
}


