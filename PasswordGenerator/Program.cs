using PasswordGeneratorLibrary;
string password = string.Empty;
int passwordLength = 0, freeCharacters = 0;

PasswordGeneratorModel PWL = new PasswordGeneratorModel();

Program();
/* The program runs infinitely in a while (true), the reason for this is to make it easily repeat its purpose.
 * It can be exited at the end of the program.
 * The program asks for the length of the desired password first, then ask for the number of letters, numbers and symbols separately.
 * After getting all the data it needs, it generates a new password using the "PasswordGeneratorLibrary" Class library.
 * After displaying the password, the user can choose to make a new one or exit the program.
 */
void Program()
{
    
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Password Generator v2.0!");
        Console.WriteLine("How long would you like your password to be?");

        passwordLength = GetPasswordLength();
        PWL.letters = GetNumberOf(nameof(PWL.letters));
        if (freeCharacters > 0)
        {
            PWL.numbers = GetNumberOf(nameof(PWL.numbers));
            if (freeCharacters > 0)
            {
                PWL.symbols = GetNumberOf(nameof(PWL.symbols));
                if (freeCharacters > 0)
                    GetRestOfCharacters();
            }
        }
        ResultWindow();

    }
}

// This method gets the length of the password.
// If the user's input is invalid it displays the error massage, after that calls itself again, until it gets a good input.
int GetPasswordLength()
{
    int result = 0;
    string? input = string.Empty;

    Console.Write("\nLength of the password: ");
    input = Console.ReadLine();
    if (Int32.TryParse(input, out result))
    {
        if (result >= 6 && result <= 25)
        {
            freeCharacters = result;
            return result;
        }

        else
        {
            ErrorMassage("\n\tThe length of the password must be between 6 and 25 characters!");
            result = GetPasswordLength();
        }
    }
    else
    {
        ErrorMassage("\n\tThe input must be a natural number!");
        result = GetPasswordLength();
    }

    return result;
}

// This method gets the number of letters, numbers, symbols.
// As a parameter it gets which one it should dedicate its massages for.
// If the user's input is invalid it displays the error massage, after that calls itself again, until it gets a good input.
int GetNumberOf(string inputType)
{
    int result = 0;
    string? input = string.Empty;

    Console.Write($"\nNumber of {inputType} in the password: ");
    input = Console.ReadLine();
    if (Int32.TryParse(input, out result))
    {
        if (result > 0 && result <= freeCharacters)
        {
            freeCharacters -= result;
            return result;
        }
        else
        {
            ErrorMassage($"\n\tThe number of the {inputType} must be equals or less than {freeCharacters}!");
            result = GetNumberOf(inputType);
        }
    }
    else
    {
        ErrorMassage("\n\tThe input must be a natural number!");
        result = GetNumberOf(inputType);
    }

    return result;
}

// This method gets the missing number of characters if there is any.
// It asks the user which character type he/she/it wants the remaining to be.
// If the user's input is invalid it displays the error massage, after that calls itself again, until it gets a good input.
void GetRestOfCharacters()
{
    string? input = string.Empty;

    Console.WriteLine($"\nThere is still {freeCharacters} left to be used!");
    Console.WriteLine("Which of the following would you like the remaining to be added to?");
    Console.WriteLine("Use: \"letter\" for Letters, \"number\" for Numbers, \"symbol\" for Symbols.");

    input = Console.ReadLine();
    switch (input)
    {
        case "letter":
            PWL.letters += freeCharacters;
            break;
        case "number":
            PWL.numbers += freeCharacters;
            break;
        case "symbol":
            PWL.symbols += freeCharacters;
            break;
        default:
            ErrorMassage("\n\tPlease choose one of the options provided!");
            GetRestOfCharacters();
            break;
    }
}

// This method generates the password, with the method located in "PasswordGeneratorLibrary" Class library.
// After getting the password, it displays it, and calls the "Exit" method.
void ResultWindow()
{
    password = PWL.PasswordMixer();
    Console.Clear();
    Console.WriteLine($"Your freshly generated password: {password}");
    Exit();
}

// This method responsible for the exit logic.
// The user can choose if he/she/it would like to still use the program or wants to exit it.
// If the user's input is invalid it calls itself again, until it gets a good input.
void Exit()
{
    string? input = string.Empty;

    Console.WriteLine("\nWould you like to exit? (y/n)");
    input = Console.ReadLine();
    if (input.ToLower().Equals("y"))
        Environment.Exit(0);
    else if (input.ToLower().Equals("n"))
    {
        Console.WriteLine("\nRestarting!");
        Thread.Sleep(2000);
    }
    else
        Exit();
}

// This method displays the error massages with red color.
void ErrorMassage(string msg)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(msg);
    Console.ForegroundColor = ConsoleColor.White;
}