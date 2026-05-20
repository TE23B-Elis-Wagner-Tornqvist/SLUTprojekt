
//Flail ärver från Weapon klassen och sätter signa egna värden
public class Flail : Weapon
{

    //Detta är konstruktorn som sätter de egna värderna
    public Flail()
    {
        sharpenIncrease = 2;    //Ökar skärpa med 2 per smithing steg
        hardenIncrease = 3;     //Ökar hårdhet med 3 per smithing steg
    }


}
