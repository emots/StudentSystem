using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public delegate void ActionOnError(string errorMs);


        public static roles CurrentUserRole { get; set; }

        public static string CurrentUserName { get; set; }

        private string name;
        private string pass;
        private string msError;   
        private ActionOnError _errorAct;

        public LoginValidation(string name, string pass, ActionOnError err)
        {
            this.name = name;
            this.pass = pass;
            this._errorAct = err;
        }
        public bool ValidateUserInput(ref User obj1)
        {
            Boolean emptyUserName;
            emptyUserName = name.Equals(String.Empty);
            if (emptyUserName == true)
            {
                msError = "No username!";
                _errorAct(msError);
                return false;
            }
             
            Boolean emptyPassword;
            emptyPassword = pass.Equals(String.Empty);
            if (emptyPassword == true)
            {
                msError = "No password!";
                _errorAct(msError);
                return false;
            }

            if (name.Length < 3)
            {
                msError = "Too short Username!";
                _errorAct(msError);
                return false;
            }

            if (pass.Length < 5)
            {
                msError = "Too short Password!";
                _errorAct(msError);
                return false;
            }

            obj1 = UserData.IsUserPassCorrect(name, pass);
            if(obj1!=null)
            {
                CurrentUserName = obj1.Username;
                CurrentUserRole = (roles)obj1.Role;

                Logger.LogActivity("Success login!");
                return true;
            }
            else
            {
                CurrentUserName = "Someone: " + name;
                CurrentUserRole = roles.ANONYMOUS;
                msError = "No such user!";
                _errorAct(msError);
                return false; 
            }                           
        }
    }
}
