Longsword longsword = new Longsword();



Console.WriteLine("Welcome to a game about smithing weapons!");

string playerName = "";
bool isValidName = false;
int numberCheck;

while (!isValidName)
{
    Console.Write("What is your name? ");
    string answer = Console.ReadLine() ?? string.Empty;
    
    // Try to parse the input as a number
    if (int.TryParse(answer, out numberCheck))
    {
        Console.WriteLine("Invalid name! Please don't enter numbers.");
    }
    else if (answer != "")
    {
        playerName = answer;
        isValidName = true;
    }
    else
    {
        Console.WriteLine("Invalid name! Please enter a name.");
    }
}

Console.WriteLine("Welcome, " + playerName + "!");


Console.WriteLine(@"Which weapon do you want to smith?
    1. Longsword
    2. Schythe
    3. Axe
    4. Flail
    ");

    string answer2 = Console.ReadLine() ?? string.Empty;

bool BigLoop = true;
while(BigLoop ==true)
{
    
    if(answer2 == "1")
    {
        Console.WriteLine("Ok, you've chosen the Longsword! Time to get smithing!");
        Console.WriteLine("Press Enter to start smithing");
        Console.ReadLine();
        Boolean IsSmithing = true;

        while(IsSmithing == true)
        {
        
        
        Console.Clear();

        longsword.Sharpen();
        longsword.Harden();
        Console.WriteLine($"nice one! Your sharpness is {longsword.GetSharpness()} and your hardness is {longsword.GetHardness()}");
        Console.WriteLine("Press Enter to keep smithing or type ''stop'' to stop smithing!");
        
        string stopSmith = Console.ReadLine() ?? string.Empty;

            if(stopSmith.ToLower() == "stop")
                {
                    IsSmithing = false;
                    BigLoop = false;
                    longsword.CheckQuality();
                    Console.WriteLine($"Your sword got a {longsword.GetQuality()} quality!");
                    Console.ReadLine();
                }
        
        }
    }
}

     

    




