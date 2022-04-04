using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject menu;
    public TextMeshProUGUI uiMenu;
    public TextMeshProUGUI uiScore;
    public GameObject mainMenu;
    private int score;

    [Header("Menu options")]
    public Food[] foodOptions;
    public int maxOrders = 6;

    [Header("Waypoints")]
    public Transform[] waypointOptions;
    private int lastWaypoint;
    private int counter;
    private Order[] deliveries;

    [Header("Sound")]
    public AudioClip receive;
    public AudioClip remove;
    public AudioClip getHit;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        mainMenu.SetActive(false);
        deliveries = new Order[maxOrders];
        source = GetComponent<AudioSource>();
        ResetMenu();
        foreach(Transform t in waypointOptions) {
            t.gameObject.SetActive(false);
        }

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            menu.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab)) {
            menu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            mainMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResetMenu() {
        Order reset = new Order(new Food("Empty", 0), waypointOptions[0]);
        for (int i=0; i<maxOrders; i++) {
            deliveries[i] = reset;
        }
        UpdateMenu();
    }

    public void ResetAt(int index) {
        Order reset = new Order(new Food("Empty", 0), waypointOptions[0]);
        deliveries[index] = reset;
        UpdateMenu();
    }

    public void AddRandom() {
        if (counter < maxOrders) {
            int randomFood = Random.Range(0, foodOptions.Length);
            int randomWaypoint = Random.Range(0, waypointOptions.Length);
            
            // Make sure the last waypoint is not the same as the new one
            while (waypointOptions[randomWaypoint].gameObject.activeSelf) {
                randomWaypoint = Random.Range(0, waypointOptions.Length);
            }

            // Create new order
            Order newOrder = new Order(foodOptions[randomFood], waypointOptions[randomWaypoint]);
            for (int i=0; i<maxOrders; i++) {
                if (deliveries[i].GetFoodName() == "Empty") {
                    deliveries[i] = newOrder;
                    break;
                }
            }
            // Activate new waypoint && Set Order 
            waypointOptions[randomWaypoint].gameObject.SetActive(true);
            waypointOptions[randomWaypoint].GetComponent<House>().SetOrder(newOrder);

            counter++;

            lastWaypoint = randomWaypoint;
            
            UpdateMenu();
            PlayAudioClip(receive);
        }
    }

    // Removes the specified order from the list
    public void RemoveOrder(Order _order) {
        if (counter > 0) {
            counter--;
            score += _order.GetFoodHealth();

            // Find order in our list
            for (int i=0; i<maxOrders; i++) {
                // Found
                if (_order.GetFoodName() == deliveries[i].GetFoodName()) {
                    ResetAt(i);
                    break;
                }
            }
            UpdateMenu();
            FindObjectOfType<Timer>().AddTime(10);
            PlayAudioClip(remove);
        }
    }

    public void UpdateMenu() {
        uiMenu.text = "MENU";
        uiScore.text = "Score: " + score.ToString();
        foreach(Order order in deliveries) {
            uiMenu.text += "\n" + order.GetFoodName() + " " + order.GetFoodHealth();
        }
    }

    public void ReceiveHit() {
        PlayAudioClip(getHit);
        for (int i=0; i<maxOrders; i++) {
            if (deliveries[i].GetFoodHealth() > 0) {
                deliveries[i].DamageFood();
            }
        }

        UpdateMenu();
    }

    public void PlayAudioClip(AudioClip _clip) {
        source.Stop();
        source.clip = _clip;
        source.Play();
    }

    public void ContinueGame() {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

}
