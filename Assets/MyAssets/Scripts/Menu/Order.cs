using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private Food delivery;
    private Transform waypoint;

    public Order(Food _food, Transform _waypoint) {
        delivery = _food;
        waypoint = _waypoint;
    }

    public Food GetFood() {
        return delivery;
    }

    public Transform GetWaypoint() {
        return waypoint;
    }

    public string GetFoodName() {
        return delivery.foodName;
    }

    public int GetFoodHealth() {
        return delivery.health;
    }

    public void DamageFood() {
        delivery.health--;
    }
}
