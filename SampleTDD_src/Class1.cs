using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SampleTDD
{


    public class UserData
    {
        public static bool CheckEmail(string emailaddress)
        {

            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        public static bool CheckPwd(string pwd)
        {
            var hasNumber = new Regex(@"[0-9]+"); //at least a digit
            var hasUpperChar = new Regex(@"[A-Z]+"); //at least an uppercase letter
            var hasSpecials = new Regex(@"[~!#@$%^&*()+=|\\{}':;.,<>/?[\]""_-]+"); //at least one special chars
            var hasMinimum8Chars = new Regex(@".{10,}"); // at least long 8

            var isValidated = hasNumber.IsMatch(pwd) && hasUpperChar.IsMatch(pwd) && hasSpecials.IsMatch(pwd) && hasMinimum8Chars.IsMatch(pwd);
            return isValidated;

        }

        public static bool CheckCC_No(string cardNo)
        {
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|5555|8901|8933)([\-\s]?[0-9]{4}){3}$");
            if (cardCheck.IsMatch(cardNo)) // check card number is valid
                return true;
            else return false;

        }

        public static bool CheckCC_Date(string expiryDate)
        {
            
            var dateCheck = new Regex(@"^(0[1-9]|1[012])\/\d{2}$");
            if (!dateCheck.IsMatch(expiryDate))
                return false; // check date format is valid as "MM/YY"

            var dateParts = expiryDate.Split('/');

            //first 2 digit of the current year
            string f2dY = DateTime.Now.Year.ToString().Substring(0, 2);
            //convert to YYYY
            var year = int.Parse((f2dY + dateParts[1]));
            var month = int.Parse(dateParts[0]);
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            //check expiry greater than today & within next 2 years
            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(2));

        }

        public static bool CheckCC_CVV(string cvv)
        {
            var cvvCheck = new Regex(@"^\d{3}$");
            if (cvvCheck.IsMatch(cvv)) // check cvv is valid as "999"
                return true;
            else return false;
        }


    }


}
