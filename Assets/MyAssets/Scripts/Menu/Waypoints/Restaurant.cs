using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    public GameObject interaction;
    public GameObject restaurant;
    private bool interacting = false;
    private int ordersInQueue = 3;

    private float timeWaited = 0f;
    private float interval = 20f;
    private int ratingMinus = 0;

    // Update is called once per frame
    void Update()
    {
        if (ordersInQueue > 0) {
            restaurant.SetActive(true);
            timeWaited += Time.deltaTime;
            if (timeWaited > interval) {
                ratingMinus++;
                timeWaited = 0;
            }
        } else {
            restaurant.SetActive(false);
        }

        if (interacting) {
            if (Input.GetKeyDown(KeyCode.E)) {
                for (int i=0; i<ordersInQueue; i++) {
                    FindObjectOfType<MenuManager>().AddRandom(ratingMinus);
                }
                ordersInQueue = 0;
            }
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            SetInteraction(true);
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            SetInteraction(false);
        }
    }

    public void SetInteraction(bool toggle) {
        interacting = toggle;
        interaction.SetActive(toggle);
    }

    public void IncreaseOrders() {
        ordersInQueue++;
    }
}
