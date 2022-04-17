using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private Food food;
    private Transform waypoint;
    
    private int rating;
    private int health;
    private int heat;

    public Order(Food _food, Transform _waypoint) {
        food = _food;
        waypoint = _waypoint;
        rating = _food.rating;
        health = _food.health;
        heat = _food.heat;
    }

    // WAYPOINT
    public Transform GetWaypoint() {
        return waypoint;
    }
    public string GetAddress() {
        return waypoint.gameObject.GetComponent<House>().deliveryName;
    }

    // FOOD 
    public void DamageFood() {
        health--;
    }
    public void ReduceFoodHeat() {
        heat--;
    }
    public void ReduceFoodRating(int damage) {
        rating -= damage;
    }
    public string GetFoodName() {
        return food.foodName;
    }
    public int GetFoodHealth() {
        return health;
    }
    public int GetFoodHeat() {
        return heat;
    }
    public int GetFoodRating() {
        return rating;
    }
    public Sprite GetFoodImage() {
        return food.image;
    }
    public Food GetFood() {
        return food;
    }

    public void ResetFood() {
        health = food.health;
        rating = food.rating;
        heat = food.heat;
    }

    public void SetNewOrder(Order newOrder) {
        food = newOrder.GetFood();
        waypoint = newOrder.GetWaypoint();
    }
}
