using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class LoginRegisterViewModel
    {
        private readonly LoginViewModel _LoginViewModel;
        private readonly RegisterUserViewModel _RegisterUserViewModel;
        public LoginRegisterViewModel() 
        {
            _LoginViewModel = new LoginViewModel();
            _RegisterUserViewModel = new RegisterUserViewModel();
        }
        public LoginRegisterViewModel( LoginViewModel LoginViewModel, RegisterUserViewModel RegisterUserViewModel)
        {
            _LoginViewModel = LoginViewModel;
            _RegisterUserViewModel = RegisterUserViewModel;
        }
        public LoginViewModel LoginViewModel => _LoginViewModel;
        public RegisterUserViewModel RegisterUserViewModel => _RegisterUserViewModel;
    }
}
