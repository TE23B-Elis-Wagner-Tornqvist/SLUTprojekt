using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Weapon
{
    //Grundläggande egenskaper för vapnets skärpa, hårdhhet och status
    protected int sharpness = 0;
    protected int hardness = 0;
    public List<string> quality = ["COMMON", "RARE", "EPIC", "LEGENDARY", "MYTHIC"];
    protected string WeaponQuality = "";
    protected float BreakRisk = 0;
    protected Boolean IsBroken = false;

    //slumpar hur mcyket skada vapnet gör för varje vapenkvalitet
    public int CommonDamage = Random.Shared.Next(0, 10);
    public int RareDamage = Random.Shared.Next(100, 350);
    public int EpicDamage = Random.Shared.Next(500, 1000);
    public int LegendaryDamage = Random.Shared.Next(1000, 5000);
    public int MythicDamage = Random.Shared.Next(10000, 50000);


    //Variabler för vaonets slutliga damage samt Dummys HP
    public int WeaponDamage;
    public int DummyHP = 1000000;

    //Värden för vapnernas individuella skärpa och hårdhet
    protected int sharpenIncrease;       
    protected int hardenIncrease;

    //returnerar vapnets nuvarande skärpa värde
    public int GetSharpness()
    {
        return sharpness;       
    }
    //returnerar vapnets nuvarande kvalitet som string
     public string GetQuality()
    {
        return WeaponQuality;
    }

    //returnerar vapnets nuvarande hårdhets värde
    public int GetHardness()
    {
        return hardness;
    }
    //returnerar vapnets status om den är sönder eller inte
    public bool GetBroken()
    {
        return IsBroken;
    }
    //returnerar värdet på risken av att vapnet förstörs
    public float GetBreakRisk()
    {
        return BreakRisk;
    }


    //metod för att öka värdet på skärpan på vapenklassens egna öknings värde
    public void Sharpen()
    {
        sharpness += sharpenIncrease;
    }
    //metod för att öka värdet på hårdheten på vaoenklassens egna öknigs värde
    public void Harden()
    {
        hardness += hardenIncrease;
    }


    // kontrollerar och sätter kvaliteten baserat på skärpan och hårdheten
    public void CheckQuality()
    {
        WeaponQuality = (sharpness, hardness) switch
        {

            ( >= 90, >= 9) => quality[4],
            ( >= 80, >= 8) => quality[3],                   
            ( >= 50, >= 5) => quality[2],                    // Ifall dem har vissa ämnen får dem en viss kvalitet från "quality" listan
            ( >= 20, >= 2) => quality[1],
            _ => quality[0],
        };

    }


    //metod för att beräkna risken att vapnet går sönder samt beräknar om den har gått sönder 
    public void BreakCheck()
    {
        BreakRisk = ((float)sharpness / 100f + (float)hardness / 10f) * 10f;

        float roll = Random.Shared.Next(0, 100);
                                                               // Tar värdet från sharpness och hardness och delar det för bättre värden
        if (roll < BreakRisk)                                
        {                                                      // * 10 på båda för att få ett nummer som går hand i hand med "roll" variabeln.
            Console.WriteLine("Oh no, your weapon broke!");      // om roll är mindre än numret ( i detta exempel 20 så misslyckas det) 20 är alltså 20% risk att misslyckas
            IsBroken = true;
        }

    }


    //Denna metod hanterar hela smithing processen för ett specifikt vapen som spelaren har valt
    public void SmithWeapon()              
    {                                                          
        Console.WriteLine($"Ok, you've chosen the {this}! Time to get smithing!");
        Console.WriteLine("Press Enter to start smithing");
        Console.ReadLine();
        RunSmithingLoop();
    }

        public void RunSmithingLoop()
    {
            bool isSmithing = true;

            //inre loop som tar hand om smithing processen
            while (isSmithing)
            {
                Console.Clear();

                //Utför smithing processen samt kollar om vapnet har gått sönder
                Sharpen();
                Harden();
                BreakCheck();

                //Avslutar både yttre samt inre loopen om vapnet gått sönder
                if (GetBroken())
                {
                    Console.ReadLine();
                    break;
                }

                //Visay nuvarnde status på vapnet (skärpa och hårdhet) samt frågar om spelaren vill sluta eller fortsätta
                Console.WriteLine($"nice one! Your sharpness is {GetSharpness()} and your hardness is {GetHardness()}");
                Console.WriteLine($"CAREFUL, the {this}'s risk of failing is at {GetBreakRisk()}%.");
                Console.WriteLine("Press Enter to keep smithing or type ''stop'' to stop smithing!");
            

                string stopSmith = Console.ReadLine() ?? string.Empty;

                //Ifall spelaren vill avsluta genom att skriva stop så avlutas smithing proccess och spelarens vapen får en viss kvalitet
                if (stopSmith.ToLower() == "stop")
                {
                   isSmithing = false;
                   ShowResult();
                }
            }   
    }      
        

public void ShowResult()
{
    Console.Clear();
    CheckQuality();                                               
    Console.WriteLine($"Your {this} got a {GetQuality()} quality!");
    Console.Write($"Now you'll be able to try your new {this} against the dummy! (just press enter)");
    Console.ReadLine();
    Console.Clear();
    TestDamage();    
}



    //Tilldelar rätt skada värde baserat på kvaliteten av vapnet
    public void DamageChooser()
    {
        if(WeaponQuality == quality[0])
        {
            WeaponDamage = CommonDamage;
        }


        if(WeaponQuality == quality[1])
        {
            WeaponDamage = RareDamage;
        }
                                                       

        if(WeaponQuality == quality[2])
        {
            WeaponDamage = EpicDamage;
        }


        if(WeaponQuality == quality[3])
        {
            WeaponDamage = LegendaryDamage;
        }


        if(WeaponQuality == quality[4])
        {
            WeaponDamage = MythicDamage;
        }
    }


    //testar skadan på vapnet mot en dummy tills den är död
    public void TestDamage()
    {


        //Bestämmer skadan baserat på kavliteten 
        DamageChooser();

        //loop tills dummy död
        while(true)
        {
            

            Console.WriteLine(@$"
        
            Dummy HP = {DummyHP}
            {WeaponQuality} {this} damage = {WeaponDamage}

            you did {WeaponDamage} damage to the dummy

            ");
        
            //drar av vapnets skada från dummy HP
             DummyHP -= WeaponDamage;

            Console.WriteLine($"Dummy has: {DummyHP} HP Left, press 'enter' to keep dealing damage");

            //Meddelar när spelaren dödat dummy
            if(DummyHP <= 0)
            {
                Console.WriteLine("Nice One! You killed the dummy :P");
            }

            Console.ReadLine();
            Console.Clear();

        }

    }

}


