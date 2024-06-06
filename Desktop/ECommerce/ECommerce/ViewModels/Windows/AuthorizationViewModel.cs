using ECommerce.Data;
using ECommerce.Extensions;
using ECommerce.Models;
using ECommerce.Services;
using ECommerce.Views.Views;
using MaterialDesignThemes.Wpf;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerce.ViewModels.Windows
{
    internal class AuthorizationViewModel
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                _createdAt = value;
                OnPropertyChanged(nameof(CreatedAt));
            }
        }

        private UserRole _role;
        public UserRole Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private readonly UsersService _usersService;
        public ICommand SaveCommand { get; }
        public ICommand LogInCommand { get; }

        public AuthorizationViewModel()
        {
            _usersService = new();

            SaveCommand = new Command(OnSaveToCreate);
        }


        private void OnLogin()
        {
            if (!_usersService.LogIn(Email, Password))
            {
                MessageBoxExtention.ShowError("You are not registered. Please register");
            }
        }

        public AuthorizationViewModel(UserAccount user)
        {
            PopulateData(user);

            _usersService = new();

            SaveCommand = new Command(OnSaveToUpdate);
        }

        private void PopulateData(UserAccount user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            CreatedAt = user.CreatedAt;
            Role = user.Role;
        }

        private void OnSaveToUpdate()
        {
            var newUser = new UserAccount()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                CreatedAt = this.CreatedAt,
                Role = this.Role,
            };

            bool isSuccess = _usersService.UpdateUser(newUser);

            if (isSuccess)
            {
                MessageBoxExtention.ShowSuccess($"{FirstName} {LastName} was updated successfully.");
            }
            else
            {
                MessageBoxExtention.ShowError($"Something went wrong to update {FirstName} {LastName}");
            }
        }

        private void OnSaveToCreate()
        {
            var newUser = new UserAccount()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                CreatedAt = DateTime.Now,
                Role = UserRole.User
            };

            bool isSuccess = _usersService.CreateUser(newUser);

            if (isSuccess)
            {
                MessageBoxExtention.ShowSuccess($"{FirstName} {LastName} was added successfully.");
            }
            else
            {
                MessageBoxExtention.ShowError($"Something went wrong to add {FirstName} {LastName}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
