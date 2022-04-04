using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string foodName;
    public int health; 

    public Food(string _name, int _health) {
        foodName = _name;
        health = _health;
    }
    
    public void DamageFood(int damage) { 
        health -= damage;
    }

}
