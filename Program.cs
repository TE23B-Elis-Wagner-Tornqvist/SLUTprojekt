Longsword longsword = new Longsword();
Scythe scythe = new Scythe();
Flail flail = new Flail();        //Instans av alla vapen
Axe axe = new Axe();

Console.WriteLine("Welcome to a game about smithing weapons!");

string playerName = "";
bool isValidName = false;
int numberCheck;

while (!isValidName)
{
    Console.Write("What is your name? ");
    string answer = Console.ReadLine() ?? string.Empty;
    
    
    if (int.TryParse(answer, out numberCheck))
    {                                                                   // kolla ifall det är nummer
        Console.WriteLine("Invalid name! Please don't enter numbers.");
    }
    else if (answer != "")
    {                              //Kolla ifall det är tomt och annars får man gå vidare och får ett namn
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


   
    bool IsValidWeapon = false;
    int numbCheck;

    while(!IsValidWeapon)
{

    string answer2 = Console.ReadLine() ?? string.Empty;
    if(answer2 == "" || !int.TryParse(answer2, out numbCheck))
    {
        Console.WriteLine("Please choose a weapon by typing the correlated number!");
    }

    else
    {
       
        IsValidWeapon = true;


    if(answer2 == "1")
{
    Weapon.SmithWeapon(longsword);
}

    if(answer2 == "2")
{
    Weapon.SmithWeapon(scythe);
}                                                          //Använder metoden i weapon.cs och sätter i det vapen som ska smidas

    if(answer2 == "3")
{
    Weapon.SmithWeapon(axe); 
}

    if(answer2 == "4")
{
    Weapon.SmithWeapon(flail);
}
     

    }


}
     

    




