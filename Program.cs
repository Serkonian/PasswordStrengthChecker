using System;
using System.Reflection;

namespace PasswordStrengthChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> weakPasswords = new HashSet<string>(); //Creates new HashSet "weakPasswords"

            string weakPasswordList = "PasswordStrengthChecker.500-worst-passwords.txt"; //The text file containing our list of weak passwords

            Assembly assembly = Assembly.GetExecutingAssembly(); //Retrieves a reference to the assembly

            using (Stream stream = assembly.GetManifestResourceStream(weakPasswordList)) //Retrieves list of weak passwords
            {
                if (stream == null) //If no list is found
                {
                    Console.WriteLine("Resource not found!");
                    return;
                }

                using (StreamReader reader = new StreamReader(stream)) //Reads the list line by line
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) //Adds the current line to our HashSet "weakPasswords"
                    {
                        weakPasswords.Add(line); 
                    }
                }
            }

            Console.WriteLine("This is a password strength checker."); 
            Console.WriteLine("Enter a password and find out how strong it is: ");

            string userPassword = Console.ReadLine(); //Stores user input as "password"

            int passwordStrength = 0; //Storage for "password strength score"

            //Check password length
            if (userPassword.Length > 8) //if password is greater than 8 characters
            {
                passwordStrength++; //Assigns a point

                if (userPassword.Length > 12) //if password is greater than 12 characters
                {
                    passwordStrength++; //Assigns a point
                }
            }

            //Check variety of input
            if (userPassword.Any(char.IsUpper)) //if "password" has uppercase character
            {
                passwordStrength++; //Assigns a point
            }

            if (userPassword.Any(char.IsLower)) //if "password" has lowercase character
            {
                passwordStrength++; //Assigns a point
            }

            if (userPassword.Any(char.IsDigit)) //if "password" has numbers
            {
                passwordStrength++; //Assigns a point
            }

            if (userPassword.Any(ch => !char.IsLetterOrDigit(ch))) //if "password" has special characters
            {
                passwordStrength++; //Assigns a point
            }

            //Comparison check
            if (!weakPasswords.Contains(userPassword.ToLower())) //if "password" not found in weakPasswords list
            {
                passwordStrength++; //Assigns a point
            }
            else
            {
                passwordStrength = 0; //Sets points to zero
            }

            if (passwordStrength >= 6) //If points amount to 6 or greater
            {
                Console.WriteLine("Password Strength: Strong");
            }
            else if (passwordStrength == 5 || passwordStrength == 4) //If points amount to either 5 or 4
            {
                Console.WriteLine("Password Strength: Moderate");
            }
            else if (passwordStrength == 2 || passwordStrength == 3) //If points amount to either 2 or 3
            {
                Console.WriteLine("Password Strength: Weak");
            }
            else
            {
                Console.WriteLine("Password Strength: Very Weak");
            }
        }
    }
}