using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "StartingStats/RestartStats")]
public class DodgerAttributes : ScriptableObject
{
    public int currentHealth;
    public int maximumHealth;
    public int currentScore; // how many dodges
    public float time; // time

    public  DodgerAttributes() 
    {

        currentHealth = 8;
        maximumHealth = 10;
        currentScore = 1;
        time = 0;



    }
        

  


}
