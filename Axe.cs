
//Axe ärver från Weapon klassen och sätter signa egna värden
public class Axe : Weapon
{
    //Detta är konstruktorn som sätter de egna värderna
    public Axe()
    {
        sharpenIncrease = 15;   //Ökar skärpa med 15 per smithing steg
        hardenIncrease = 1;     //Ökar hårdhet med 1 per smithing steg
    }

}
