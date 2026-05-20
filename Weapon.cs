using System.Net.Http.Headers;
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
            ( >= 80, >= 8) => quality[3],                    //En switch för att kolla om sharpness och hardness har vissa värden
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
    public static void SmithWeapon(Weapon w)              
    {                                                      

        bool BigLoop = true;
        //En yttre loop
        while(BigLoop == true)
{

        Console.WriteLine($"Ok, you've chosen the {w}! Time to get smithing!");
        Console.WriteLine("Press Enter to start smithing");
        Console.ReadLine();
        Boolean IsSmithing = true;

        //inre loop som tar hand om smithing processen
        while (IsSmithing == true)
        {


            Console.Clear();

            //Utför smithing processen samt kollar om vapnet har gått sönder
            w.Sharpen();
            w.Harden();
            w.BreakCheck();

            //Avslutar både yttre samt inre loopen om vapnet gått sönder
            if (w.GetBroken() == true)
            {
                IsSmithing = false;     
                BigLoop = false;
                Console.ReadLine();
                break;
            }

            //Visay nuvarnde status på vapnet (skärpa och hårdhet) samt frågar om spelaren vill sluta eller fortsätta
            Console.WriteLine($"nice one! Your sharpness is {w.GetSharpness()} and your hardness is {w.GetHardness()}");
            Console.WriteLine($"CAREFUL, the {w}'s risk of failing is at {w.GetBreakRisk()}%.");
            Console.WriteLine("Press Enter to keep smithing or type ''stop'' to stop smithing!");

            string stopSmith = Console.ReadLine() ?? string.Empty;

            //Ifall spelaren vill avsluta genom att skriva stop så avlutas smithing proccess och spelarens vapen får en viss kvalitet
            if (stopSmith.ToLower() == "stop")
            {
                Console.Clear();
                IsSmithing = false;
                BigLoop = false; 
                w.CheckQuality();                                               
                Console.WriteLine($"Your {w} got a {w.GetQuality()} quality!");
                Console.Write($"Now you'll be able to try your new {w} against the dummy! (just press enter)");
                Console.ReadLine();
                Console.Clear();
                TestDamage(w);
            }

        }
    }

    }


    //Tilldelar rätt skada värde baserat på kvaliteten av vapnet
    public static void DamageChooser(Weapon w)
    {
        if(w.WeaponQuality == w.quality[0])
        {
            w.WeaponDamage = w.CommonDamage;
        }


        if(w.WeaponQuality == w.quality[1])
        {
            w.WeaponDamage = w.RareDamage;
        }
                                                       

        if(w.WeaponQuality == w.quality[2])
        {
            w.WeaponDamage = w.EpicDamage;
        }


        if(w.WeaponQuality == w.quality[3])
        {
            w.WeaponDamage = w.LegendaryDamage;
        }


        if(w.WeaponQuality == w.quality[4])
        {
            w.WeaponDamage = w.MythicDamage;
        }
    }


    //testar skadan på vapnet mot en dummy tills den är död
    public static void TestDamage(Weapon w)
    {


        //Bestämmer skadan baserat på kavliteten 
        DamageChooser(w);

        //loop tills dummy död
        while(true)
        {
            
        

        Console.WriteLine(@$"
        
        Dummy HP = {w.DummyHP}
        {w.WeaponQuality} {w} damage = {w.WeaponDamage}

        you did {w.WeaponDamage} damage to the dummy

        ");
        
        //drar av vapnets skada från dummy HP
         w.DummyHP -= w.WeaponDamage;

        Console.WriteLine($"Dummy has: {w.DummyHP} HP Left, press 'enter' to keep dealing damage");

        //Meddelar när spelaren dödat dummy
        if(w.DummyHP <= 0)
            {
                Console.WriteLine("Nice One! You killed the dummy :P");
            }

        Console.ReadLine();
        Console.Clear();

        }

    }

}
