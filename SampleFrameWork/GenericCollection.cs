using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SampleFrameWork
{
    class GenericCollection
    {

        static void Main(string[] args)
        {
            //listExample();
            //DictionaryExample();
            //hashSetExample();
            SortedList();
        }
        private static void listExample()
        {
            string[] oldVal = { "Kiwi", "Watermelon", "Mango" };
            List<string> fruits = new List<string>(oldVal);
            fruits.Add("Apples");
            fruits.Add("Banana");
            fruits.Add("Grapes");
            fruits.Add("Orange");
            fruits.Remove("Mango");
            foreach (var item in fruits)
            {
                Console.WriteLine(item);
            }

            List<int> Numbers = new List<int>();
            Numbers.Add(123);
            Numbers.Add(456);
            Numbers.Add(489);
            Numbers.Insert(2, 888);
            foreach (var item in Numbers)
            {
                Console.WriteLine(item);
            }
        }
        private static void hashSetExample()
        {
            HashSet<string> basket = new HashSet<string>();
            basket.Add("Mallika Mangoes");
            if (!basket.Add("Benisha Mangoes"))
            {
                Console.WriteLine("This already exists");
            }
            basket.Add("Ratnagiri Mangoes");
            basket.Add("Alphonso Mangoes");
            basket.Add("Raspuri Mangoes");
            Console.WriteLine("The Count of the basket is " + basket.Count);
            foreach (var item in basket)
            {
                Console.WriteLine(item);
            }
        }

        static Dictionary<string, string> users = new Dictionary<string, string>();

        private static void Signin()
        {
        RETRY:
            var uname = Utilities.Prompt("Enter the username");
            var pasw = Utilities.Prompt("Enter the password");
            if (users.ContainsKey(uname))
            {
                if (users[uname] == pasw)
                {
                    Console.WriteLine("Welcome User");
                }
                else
                {
                    Console.WriteLine("Inbalid Password");
                    goto RETRY;
                }
                
            }
            else
            {
                Console.WriteLine("User Already Exists");
                goto RETRY;
            }
            //users.Add(uname, pasw);
        }
        private static void Signup()
        {
        RETRY:
            var uname = Utilities.Prompt("Enter the username");
            var pasw = Utilities.Prompt("Enter the password");
            if (users.ContainsKey(uname))
            {
                Console.WriteLine("User Already Exists");
                goto RETRY;
            }
            //users.Add(uname, pasw);

        }
        private static void DictionaryExample()
        {
            do
            {
                var choice = Utilities.Prompt("Press 1 to Sign In(Login) and 2 to Sign Up(Register)");
                if (choice == "1")
                {
                    Signin();
                }
                else if (choice == "2")
                {
                    Signup();
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            } while (true);
        }
        private static void SortedList()
        {
            SortedList<string, long> Sort = new SortedList<string, long>();
            Sort.Add("Mohan", 9958632147);
            Sort.Add("Mohana", 998163772147);
            Sort.Add("Mohanaa", 9458632147);
            Sort.Add("Mohanaaa", 9358632147);
            Sort.Add("Mohanaaaa", 9998632147);
            foreach (var contact in Sort)
            {
                Console.WriteLine($"{contact.Key}-{contact.Value}");
            }
        }
    }
}
