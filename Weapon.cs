public class Weapon
{

    protected int sharpness = 0;
    protected int hardness = 0;
    public List<string> quality = ["COMMON", "RARE", "EPIC", "LEGENDARY", "MYTHIC"];
    protected string WeaponQuality = "";
    float BreakRisk = 0;





    public void CheckQuality()
    {
        WeaponQuality = (sharpness, hardness) switch
        {

            (>= 100, >= 10) => quality[4],
            (>= 80, >= 8) => quality[3],
            (>= 50, >= 5) => quality[2],
            (>= 20, >= 2) => quality[1],
            _             => quality[0],
        };

    }


    public void BreakCheck()
    {
        BreakRisk = ((float) sharpness / 100f + (float) hardness / 10f) * 50f;
        
    }



}
