using System;
using System.Linq;
using System.Collections.Generic;

namespace PasswordStrengthChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a password strength checker."); 
            Console.WriteLine("Enter a password and find out how strong it is: ");

            string password = Console.ReadLine(); //Stores user input as "password"

            int strength = 0; //Storage for "password strength score"
            //Check length of input
            if (password.Length >= 8) //if "password" is greater than or equal to 8 characters
            {
                strength++; //Assigns a point
            }
            
            if (password.Length >= 12) //if "password" is great than or equal to 12 characters
            {
                strength++; //Assigns a point
            }

            if (password.Length > 12) //if "password" is greater than 12 characters
            {
                strength++; //Assigns a point
            }

            //Check variety of input
            if (password.Any(char.IsUpper)) //if "password" has uppercase character
            {
                strength++; //Assigns a point
            }

            if (password.Any(char.IsLower)) //if "password" has lowercase character
            {
                strength++; //Assigns a point
            }

            if (password.Any(char.IsDigit)) //if "password" has numbers
            {
                strength++; 
            }

            if (password.Any(ch => !char.IsLetterOrDigit(ch))) //if "password" has special characters
            {
                strength++; //Assigns a point
            }

            string[] weakPasswords = { "123456", "password", "123456789", "qwerty", "abc123", "111111", "12345678", "admin", "letmein", "welcome", "football", "12345", "1234", "2025", "baseball", "superman", "princess", "dragon", "harrypotter", "starwars", "iloveyou", "123", "master", "sunshine", "password123" };
            //Compare input against list
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Invalid (Empty Password)"); //Lacking user input
            }

            if (!weakPasswords.Contains(password.ToLower())) //if "password" not found in list
            {
                strength++; //Assigns a point
            }
            else
            {
                strength = 0;
            }

            if (strength == 7 || strength == 6)
            {
                Console.WriteLine("Password Strength: Strong"); //Output rating
            }
            else if (strength == 5 || strength == 4)
            {
                Console.WriteLine("Password Strength: Moderate"); //Output rating
            }
            else if (strength == 2 || strength == 3)
            {
                Console.WriteLine("Password Strength: Weak"); //Output rating
            }
            else
            {
                Console.WriteLine("Password Strength: Very Weak"); //Output rating
            }
        }           
    }
}

