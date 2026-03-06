public class Longsword : Weapon
{


    public void Sharpen()
    {
        sharpness += 10;
    }

    public int GetSharpness()
    {
        return sharpness;
    }

    public string GetQuality()
    {
        return WeaponQuality;
    }

    public void Harden()
    {
        hardness += 1;
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


    


}
