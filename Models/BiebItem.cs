using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bieb.Models
{
    public class BiebItem : NotifyPropertyChanged
    {
        //Krijg data en set data
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

		//Krijg data en set data
		private string _titel;
        public string Titel
        {
            get
            {
                return _titel;
            }
            set
            {
                _titel = value;
                RaisePropertyChange(); // Laat viewmodel weten voor veranderingen
			}
        }
        private string _mediaType;
        public string MediaType
        {
            get
            {
                return _mediaType;
            }
            set
            {
                _mediaType = value;
                RaisePropertyChange(); // Laat viewmodel weten voor veranderingen
			}
        }

        // returns de naam van authors als string
        

        public ObservableCollection<Author> Authors { get; set; } = new();


        
        public string AuthorsAsString => string.Join(", ", Authors.Select(x => x.Name));

    }
}
