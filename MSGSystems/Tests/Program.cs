using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static List<(string Name, string Password)> userAccounts = new List<(string Name, string Password)>();
    const string filePath = "userAccounts.txt";
    const string mailsFilePath = "MAILS.txt";

    static void Main()
    {
        LoadAccounts(); 
        DisplayWelcomeAndOptions(); 

        
        while (true)
        {
            string userInput = Console.ReadLine();
            ClearLine();

            switch (userInput)
            {
                case "2":
                    Login();
                    break;
                case "1":
                    CreateAccount();
                    break; 
                default:
                    Console.WriteLine("Invalid choice. Please enter '1' to create an account or '2' to log in.");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();
        ClearLine();

        Console.WriteLine("Please enter your password:");
        string password = Console.ReadLine();
        ClearLine();

        
        userAccounts.Add((name, password));
        SaveAccounts(); 
        Console.WriteLine("Account created successfully!");
    }

    static void Login()
    {
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();
        ClearLine();

        Console.WriteLine("Please enter your password:");
        string password = Console.ReadLine();
        ClearLine();

        bool loginSuccess = false;

        foreach (var account in userAccounts)
        {
            if (account.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && account.Password == password)
            {
                loginSuccess = true;
                break; 
            }
        }

        if (loginSuccess)
        {
            Console.WriteLine("Login successful! Welcome, " + name + "!");
            Thread.Sleep(2000);
            Console.Clear(); 

            
            DisplayPostLoginOptions();
        }
        else
        {
            Console.Clear(); 
            Console.WriteLine("Invalid credentials. Please try again.");
            Thread.Sleep(2000); 
            Console.Clear(); 
            DisplayWelcomeAndOptions(); 
        }
    }

    static void SaveAccounts()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var account in userAccounts)
            {
                writer.WriteLine($"{account.Name},{account.Password}");
            }
        }
    }

    static void LoadAccounts()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        userAccounts.Add((parts[0], parts[1]));
                    }
                }
            }
        }
    }

    
    static void DisplayWelcomeAndOptions()
    {
        var LISI = "Oops, looks like you have to log-in/sign-in";
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
        Thread.Sleep(2000);
        ClearLine();
        Console.WriteLine("Welcome to the Setro messaging service");
        Thread.Sleep(2000);
        ClearLine();
        Console.WriteLine("Your most secure messaging service");
        Thread.Sleep(2000);
        ClearLine();
        Console.WriteLine(LISI);
        Thread.Sleep(2000);
        ClearLine();

        // Display options
        string[] LISIO = { "1-Create account", "2-Log-in" };
        foreach (var option in LISIO)
        {
            Console.WriteLine(option);
        }

        Console.WriteLine("Please enter the number equivalent to what you want to do:");
    }

    static void DisplayPostLoginOptions()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1- Add friend");
            Console.WriteLine("2- Msg friend");

            string userInput = Console.ReadLine();
            ClearLine();

            switch (userInput)
            {
                case "1":
                    AddFriend();
                    break; 
                case "2":
                    MsgFriend();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter '1' or '2'.");
                    break;
            }
        }
    }

    static void AddFriend()
    {
        Console.WriteLine("Enter the Gmail address of the friend you want to add:");
        string friendEmail = Console.ReadLine();
        ClearLine();

       
        if (friendEmail.EndsWith("@gmail.com"))
        {
            SaveFriendEmail(friendEmail); 
            Console.WriteLine($"Gmail address {friendEmail} has been saved.");
        }
        else
        {
            Console.WriteLine("Invalid Gmail address. Please ensure it ends with '@gmail.com'.");
        }
    }

    static void MsgFriend()
    {
        Console.WriteLine("This feature is under construction. Add your functionality here!");
        Thread.Sleep(2000); 
        Console.Clear(); 
    }

    static void SaveFriendEmail(string email)
    {
        using (StreamWriter writer = new StreamWriter(mailsFilePath, append: true))
        {
            writer.WriteLine(email);
        }
    }

    
    static void ClearLine()
    {
        int currentLineCursor = Console.CursorTop - 1;  
        Console.SetCursorPosition(0, currentLineCursor); 
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
