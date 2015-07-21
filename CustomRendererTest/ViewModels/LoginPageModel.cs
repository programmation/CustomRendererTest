using System;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomRendererTest
{
    [ImplementPropertyChanged]
    public class LoginPageModel
    {
        public string UserId { get; set; }
        public string Password { get; set;}

        private ICommand _rememberMeToggleCommand;

        public ICommand RememberMeToggleCommand {
            get {
                return _rememberMeToggleCommand = _rememberMeToggleCommand ?? new Command(() =>
                    {
                    
                    });
            }
        }

        private ICommand _loginCommand;

        public ICommand LoginCommand {
            get {
                return _loginCommand = _loginCommand ?? new Command(() =>
                    {
                    
                    });
            }
        }

        private ICommand _forgotPasswordCommand;

        public ICommand ForgotPasswordCommand {
            get {
                return _forgotPasswordCommand = _forgotPasswordCommand ?? new Command(() =>
                    {
                    
                    });
            }
        }

        public LoginPageModel()
        {
        }
    }
}

