using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private Food food;
    private Transform waypoint;
    
    public Order(Food _food, Transform _waypoint) {
        food = _food;
        waypoint = _waypoint;
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
        food.health--;
    }
    public void ReduceFoodHeat() {
        food.heat--;
    }
    public void ReduceFoodRating() {
        food.rating--;
    }
    public string GetFoodName() {
        return food.foodName;
    }
    public int GetFoodHealth() {
        return food.health;
    }
    public int GetFoodHeat() {
        return food.heat;
    }
    public int GetFoodRating() {
        return food.rating;
    }
    public Sprite GetFoodImage() {
        return food.image;
    }
    public Food GetFood() {
        return food;
    }

    public void SetNewOrder(Order newOrder) {
        food = newOrder.GetFood();
        waypoint = newOrder.GetWaypoint();
    }
}
