using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject[] foodStats;
    public TextMeshProUGUI uiScore;
    private int score;

    [Header("Menu options")]
    public Food[] foodOptions;
    public int maxOrders = 6;

    [Header("Waypoints")]
    public GameObject[] waypointOptions;
    private int counter;
    private Order[] deliveries;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject food in foodStats) {
            food.SetActive(false);
        }
        deliveries = new Order[maxOrders];
        ResetMenu();
        foreach(GameObject waypoint in waypointOptions) {
            waypoint.SetActive(false);
        }

        score = 0;
    }

   

    public void ResetMenu() {
        Order reset = new Order(new Food("Empty", 0, 0, 0), waypointOptions[0].transform);
        for (int i=0; i<maxOrders; i++) {
            deliveries[i] = reset;
        }
        UpdateMenu();
    }

    public void ResetAt(int index) {
        Order reset = new Order(new Food("Empty", 0, 0, 0), waypointOptions[0].transform);
        deliveries[index] = reset;
        UpdateMenu();
    }

    public void AddRandom() {
        if (counter < maxOrders) {
            int randomFood = Random.Range(0, foodOptions.Length);
            int randomWaypoint = Random.Range(0, waypointOptions.Length);
            
            // Make sure the waypoint is not already activated
            while (waypointOptions[randomWaypoint].activeSelf) {
                randomWaypoint = Random.Range(0, waypointOptions.Length);
            }

            // Create new order
            Order newOrder = new Order(foodOptions[randomFood], waypointOptions[randomWaypoint].transform);
            for (int i=0; i<maxOrders; i++) {
                if (deliveries[i].GetFoodName() == "Empty") {
                    deliveries[i] = newOrder;
                    foodStats[i].SetActive(true);
                    break;
                }
            }
            // Activate new waypoint && Set Order 
            waypointOptions[randomWaypoint].gameObject.SetActive(true);
            waypointOptions[randomWaypoint].GetComponent<House>().SetOrder(newOrder);

            counter++;

            UpdateMenu();
            SoundManager.Instance.PlayReceive();
        }
    }

    // Removes the specified order from the list
    public void RemoveOrder(Order _order) {
        if (counter > 0) {
            counter--;
            score += _order.GetFoodRating();

            // Find order in our list
            for (int i=0; i<maxOrders; i++) {
                // Found
                if (_order.GetAddress() == deliveries[i].GetAddress()) {
                    ResetAt(i);
                    break;
                }
            }
            UpdateMenu();
            FindObjectOfType<Timer>().AddTime(10);
            SoundManager.Instance.PlayRemove();
        }
    }

    public void UpdateMenu() {
        uiScore.text = "Score: " + score.ToString();
        for (int i=0; i<deliveries.Length; i++) {
            if (deliveries[i].GetFoodName() == "Empty") {
                foodStats[i].SetActive(false);
            } else {
                foodStats[i].SetActive(true);
                foodStats[i].GetComponent<FoodStatsController>().SetHealth(deliveries[i].GetFoodHealth());
                foodStats[i].GetComponent<FoodStatsController>().SetRating(deliveries[i].GetFoodRating());
                foodStats[i].GetComponent<FoodStatsController>().SetHeat(deliveries[i].GetFoodHeat());
                foodStats[i].GetComponent<FoodStatsController>().ChangeSprite(deliveries[i].GetFoodImage());
                foodStats[i].GetComponent<FoodStatsController>().SetAddress(deliveries[i].GetAddress());
            }
        }
    }

    public void ReceiveHit() {
        SoundManager.Instance.PlayHit();
        for (int i=0; i<maxOrders; i++) {
            if (deliveries[i].GetFoodHealth() > 0 && deliveries[i].GetFoodName() != "Empty") {
                deliveries[i].DamageFood();
            }
        }

        UpdateMenu();
    }

   
}
