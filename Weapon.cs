public class Weapon
{

    protected int sharpness = 0;
    protected int hardness = 0;
    public List<string> quality = ["COMMON", "RARE", "EPIC", "LEGENDARY", "MYTHIC"];
    protected string WeaponQuality = "";
    protected float BreakRisk = 0;
   protected Boolean IsBroken = false;




    public void CheckQuality()
    {
        WeaponQuality = (sharpness, hardness) switch
        {

            (>= 90, >= 9) => quality[4],
            (>= 80, >= 8) => quality[3],
            (>= 50, >= 5) => quality[2],
            (>= 20, >= 2) => quality[1],
            _             => quality[0],
        };

    }


    public void BreakCheck()
    {
        BreakRisk = ((float) sharpness / 100f + (float) hardness / 10f) * 50f;

        float roll = Random.Shared.Next(0, 100);

        if(roll < BreakRisk)
        {
            Console.WriteLine("Oh no, your sword broke!");
            IsBroken = true;
        }

    }



}
