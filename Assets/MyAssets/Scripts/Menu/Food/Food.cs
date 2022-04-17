using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public Sprite image;
    
    public string foodName;
    
    [Header("Starting Food Attributes")]
    public int health; 
    public int heat;
    public int rating;
    

    public Food(string _name, int _health, int _heat, int _rating) {
        foodName = _name;
        health = _health;
        heat = _heat;
        rating = _rating;
    }
}
