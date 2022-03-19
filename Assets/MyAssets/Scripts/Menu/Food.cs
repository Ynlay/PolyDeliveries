using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string foodName;
    public int health; 

    
    public void DamageFood(int damage) { 
        health -= damage;
    }

}
