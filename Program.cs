 //Skapar en instans av alla tillgängliga vapen
Longsword longsword = new Longsword();
Scythe scythe = new Scythe();
Flail flail = new Flail();       
Axe axe = new Axe();

//skriver ut ett välkommen meddelande
Console.WriteLine("Welcome to a game about smithing weapons!");

//deklarerar variabler för spelarens namn samt valideringslogik
string playerName = "";
bool isValidName = false;
int numberCheck;

//Loop tills spelaren skriver ett giltigt namn
while (!isValidName)
{
    Console.Write("What is your name? ");
    string answer = Console.ReadLine() ?? string.Empty;
    
        // kolla ifall det är nummer, -nummer är inte tillåtet
        if (int.TryParse(answer, out numberCheck))
        {                                                                   
            Console.WriteLine("Invalid name! Please don't enter numbers.");
        }
            //Kolla ifall svaret inte är tomt, om det är giltigt så sparas namnet oh loopen avslutas
            else if (answer != "")
            {                              
                playerName = answer;
                isValidName = true;
            }
                //Om svaret är tomt får spelaren en meddelande om att förska igen ochskriva ett namn
                else
                {
                    Console.WriteLine("Invalid name! Please enter a name.");
                }
}

//välkommst medelande med spelarens namn
Console.WriteLine("Welcome, " + playerName + "!");

//Visar vapenmeny och valbara alternativ
Console.WriteLine(@"Which weapon do you want to smith?
    1. Longsword
    2. Schythe
    3. Axe
    4. Flail
    ");


   //variablar för validering samt vapenval
    bool IsValidWeapon = false;
    int numbCheck;

//looop tills spelaren väljer ett giltigt vapenb alternativ
    while(!IsValidWeapon)
{

    string answer2 = Console.ReadLine() ?? string.Empty;

        //Kollar så att det inte är tomt samt är ett nummer 
        if(answer2 == "" || !int.TryParse(answer2, out numbCheck))
        {
            Console.WriteLine("Please choose a weapon by typing the correlated number!");
        }

            else
            {
                //Gör valet giltigt och avslutar loopen
                IsValidWeapon = true;

                //Anropar smithWeapon metoden med det valda vapnet
                if(answer2 == "1")
                {
                    longsword.SmithWeapon();
                }

                if(answer2 == "2")
                {
                    scythe.SmithWeapon();
                }                                                          //Använder metoden i weapon.cs och sätter i det vapen som ska smidas

                if(answer2 == "3")
                {
                    axe.SmithWeapon(); 
                }

                if(answer2 == "4")
                {
                    flail.SmithWeapon();
                }
            }
}
     

    




