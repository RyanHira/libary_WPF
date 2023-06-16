using Bieb.Models;
using Bieb.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using static Bieb.Commands.Icommand;
using System.ComponentModel;
using System.Windows;

namespace Bieb.ViewModel
{
    class AuthorViewModel : ObservableObject
    {

        private readonly BiebDbContext _db;
        private Author selectedAuthor; //selected author
        private bool enableDeleteButton = false; //indicate whether delete button should be active
        private bool enableEditButton = false; //indicate whether edit button should be active

        public ObservableCollection<Author> Authors { get; set; } = new(); //collection of authors
        public Author SelectedAuthor //selected author
		{
            get => selectedAuthor; set
            {
                selectedAuthor = value;
                SetProperty(ref enableDeleteButton, value is not null, nameof(EnableDeleteButton));
                SetProperty(ref enableEditButton, value is not null, nameof(EnableEditButton));
                OnPropertyChanged(nameof(SelectedAuthor));
            }
        }
        public bool EnableDeleteButton { get => enableDeleteButton; set => enableDeleteButton = value; } 
        public bool EnableEditButton { get => enableEditButton; set => enableEditButton = value; } 

        // ICommands 
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; }

        public ICommand BackCommand { get; }


        public AuthorViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-MKHJ4B1;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            LoadData(); //laad data van database

            //commands
            AddCommand = new RelayCommand(AddAuthor);
            DeleteCommand = new RelayCommand(DeleteAuthor);
            EditCommand = new RelayCommand(EditAuthor);
            BackCommand = new DelegateCommand(ExecuteBackCommand);
        }

        private void DeleteAuthor() //delete selected author
        {
            if (SelectedAuthor is null)
            {
                return;
            }

            _db.Authors.Remove(SelectedAuthor);
            _db.SaveChanges();
            Authors.Remove(SelectedAuthor);
        }

        //voeg command toe en open nieuwe window
        private void AddAuthor()
        {
            var addAuthorWindow = new AddOrUpdateAuthorView(null);
            addAuthorWindow.ShowDialog();

            LoadData();
        }
        private void EditAuthor() //edit selected author
        {
            if(SelectedAuthor is null)
            { 
                return; 
            }

            var addAuthorWindow = new AddOrUpdateAuthorView(SelectedAuthor);
            
            addAuthorWindow.ShowDialog();

            LoadData();
        }

        private void ExecuteBackCommand(object parameter)
        {
            // Create de MainWindow
            MainWindow mainWindow = new MainWindow();

            // krijg current window
            Window currentWindow = Application.Current.MainWindow;

            // Zet de MainWindow als window
            Application.Current.MainWindow = mainWindow;

            // Sluit current window
            currentWindow.Close();

            // Show de MainWindow
            mainWindow.Show();
        }

        //Ophalen data van database
        private void LoadData()
        {
            
            var newData = _db.Authors.Include(x => x.BiebItems).ToList();

            Authors.Clear();
            foreach (var item in newData)
            {
                Authors.Add(item);
            }
        }
        protected new virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
