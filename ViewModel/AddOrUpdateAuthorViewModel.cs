using Bieb.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace Bieb.ViewModel
{
    public class AddOrUpdateAuthorViewModel : ObservableObject
    {
        public Author Author { get; }
        
        //laat zien of je edit mode zit
        private bool _isEditing;

        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }

        public ICommand SaveCommand { get; } //command voor save changes

        private BiebDbContext _db;

        public AddOrUpdateAuthorViewModel(Author? author)
        {
            // save de database context. Veramder de string COMPUTERS.
            SaveCommand = new RelayCommand(Save);
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-MKHJ4B1;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            //set author bepaal of editing is
            Author = author ?? new();
            IsEditing = author != null;
        }


        //save changed to database
        public void Save()
        {
            if (!IsEditing)
            {
                _db.Authors.Add(Author); //add to database
            }
            _db.SaveChanges(); //save database
            
            IsEditing = true;
        }
    }
}
