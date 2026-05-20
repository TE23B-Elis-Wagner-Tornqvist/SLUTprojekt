
//Scythe ärver från Weapon klassen och sätter signa egna värden
public class Scythe : Weapon
{
    //Detta är konstruktorn som sätter de egna värderna
    public Scythe()
    {
        sharpenIncrease = 5;    //Ökar skärpa med 5 per smithing steg
        hardenIncrease = 2;     //Ökar hårdhet med 2 per smithing steg
    }


}
