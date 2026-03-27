public class Weapon
{

    protected int sharpness = 0;
    protected int hardness = 0;
    public List<string> quality = ["COMMON", "RARE", "EPIC", "LEGENDARY", "MYTHIC"];
    protected string WeaponQuality = "";
    protected float BreakRisk = 0;
    protected Boolean IsBroken = false;

    protected int sharpenIncrease;       //en variabrl för så att varje vapen kan ha sitt egna värde

    protected int hardenIncrease;

    public int GetSharpness()
    {
        return sharpness;       //får värdet av sharpness
    }

     public string GetQuality()
    {
        return WeaponQuality;
    }


    public int GetHardness()
    {
        return hardness;
    }

    public bool GetBroken()
    {
        return IsBroken;
    }

    public float GetBreakRisk()
    {
        return BreakRisk;
    }


    
    public void Sharpen()
    {
        sharpness += sharpenIncrease;
    }

    public void Harden()
    {
        hardness += hardenIncrease;
    }



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



    public void BreakCheck()
    {
        BreakRisk = ((float)sharpness / 100f + (float)hardness / 10f) * 50f;

        float roll = Random.Shared.Next(0, 100);
                                                               // Tar värdet från sharpness och hardness och delar det för bättre värden
        if (roll < BreakRisk)                                
        {                                                      // * 50 på båda för att nummer mellan 0 - 100.
            Console.WriteLine("Oh no, your sword broke!");      // om roll är mindre än numret ( i detta exempel 20 så misslyckas det) 20 är alltså 20% risk att misslyckas
            IsBroken = true;
        }

    }






    public static void SmithWeapon(Weapon w)                //en metod för att få specifika värden för vissa vapen klasser
    {                                                       // När man kallar metod i program.cs så blir "w" den klassen man vill använda

        bool BigLoop = true;
        while(BigLoop ==true)
{

        Console.WriteLine($"Ok, you've chosen the {w}! Time to get smithing!");
        Console.WriteLine("Press Enter to start smithing");
        Console.ReadLine();
        Boolean IsSmithing = true;

        while (IsSmithing == true)
        {


            Console.Clear();

            w.Sharpen();
            w.Harden();
            w.BreakCheck();
            if (w.GetBroken() == true)
            {
                IsSmithing = false;     //Kollar med hjälp av getBroken om svärdet har misslyckats och stoppar då loopen
                BigLoop = false;
                Console.ReadLine();
                break;
                
            }
            Console.WriteLine($"nice one! Your sharpness is {w.GetSharpness()} and your hardness is {w.GetHardness()}");
            Console.WriteLine($"CAREFUL, the {w}'s risk of failing is at {w.GetBreakRisk()}%.");
            Console.WriteLine("Press Enter to keep smithing or type ''stop'' to stop smithing!");

            string stopSmith = Console.ReadLine() ?? string.Empty;

            if (stopSmith.ToLower() == "stop")
            {
                IsSmithing = false;
                BigLoop = false; 
                w.CheckQuality();                                                //kollar kvaliteten och ger ett resultat
                Console.WriteLine($"Your {w} got a {w.GetQuality()} quality!");
                Console.ReadLine();
            }

        }
    }

    }


}
