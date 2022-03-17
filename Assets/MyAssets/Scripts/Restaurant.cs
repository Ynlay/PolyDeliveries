using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    public GameObject interaction;
    private bool interacting = false;

    // Update is called once per frame
    void Update()
    {
        if (interacting) {
            if (Input.GetKeyDown(KeyCode.E)) {
                SetInteraction(false);
                FindObjectOfType<MenuManager>().AddRandom();
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
}
