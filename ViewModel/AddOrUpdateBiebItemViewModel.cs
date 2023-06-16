using Bieb.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Bieb.ViewModel
{
    class AddOrUpdateBiebItemViewModel : ObservableObject
    {

        public BiebItem BiebItem { get; set; }

        //observable authors
        public ObservableCollection<Author> Authors { get; set; }

        //Geslecteerde authors for biebitems
        public List<Author> SelectedAuthors { get; set; } = new();
        
        //check of het in editing mode is
        public bool IsEditing { get; private set; }


        public ICommand SaveCommand { get; set; } //opslaan command

        private BiebDbContext _db;

        public AddOrUpdateBiebItemViewModel(BiebItem? biebItem)
        {
            // save command en database context
            SaveCommand = new RelayCommand(Save);
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);
            //Laad de authors van de database in de authors collecttion and zet in lijst
            Authors = new ObservableCollection<Author>(_db.Authors.ToList());

            //set properties en bepaal of het in editting mode is
            BiebItem = biebItem ?? new();
            IsEditing = biebItem != null;
        }

        //save changes
        public void Save()
        {
            
            BiebItem.Authors.Clear();
            foreach (var author in SelectedAuthors)
            {
                BiebItem.Authors.Add(author);
            }

            if (!IsEditing)
            {
                //Voeg een nieuwe Item toe in database als niet edit
                _db.BiebItems.Add(BiebItem);
            }

            _db.SaveChanges(); //opslaan in database.

            IsEditing = true; 
        }
    }
}
