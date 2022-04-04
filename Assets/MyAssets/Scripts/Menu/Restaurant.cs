using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    public GameObject interaction;
    public GameObject restaurant;
    private bool interacting = false;
    private int ordersInQueue = 3;

    // Update is called once per frame
    void Update()
    {
        if (ordersInQueue > 0) {
            restaurant.SetActive(true);
        } else {
            restaurant.SetActive(false);
        }

        if (interacting) {
            if (Input.GetKeyDown(KeyCode.E)) {
                for (int i=0; i<ordersInQueue; i++) {
                    FindObjectOfType<MenuManager>().AddRandom();
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
