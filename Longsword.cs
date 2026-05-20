
//Longsword ärver från Weapon klassen och sätter signa egna värden
public class Longsword : Weapon
{
    //Detta är konstruktorn som sätter de egna värderna
    public Longsword()
    {
        sharpenIncrease = 10;     //Ökar skärpa med 10 per smithing steg
        hardenIncrease = 1;       //Ökar hårdhet med 1 per smithing steg
    }


}
