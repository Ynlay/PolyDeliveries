using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{

    public float interval; 
    private float timer; 

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        // FindObjectOfType<MenuManager>().AddRandom();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval) {
            // play sound
            FindObjectOfType<Restaurant>().IncreaseOrders();
            timer = 0;
        }
    }
}
