using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    // INTERACTING
    public GameObject interaction;
    private bool interacting = false;
    // NPC
    private Animator npcAnim;
    // ORDER
    private Order order;
    public string deliveryName;
    
    void Start()
    {
        npcAnim = GetComponentInChildren<Animator>();  
        npcAnim.SetBool("Cellphone", true); 
    }
    // Update is called once per frame
    void Update()
    {
        if (interacting) {
            if (Input.GetKeyDown(KeyCode.E)) {
                SetInteraction(false);
                FindObjectOfType<MenuManager>().RemoveOrder(order);
                order = null;
                Invoke("Disable", 2.0f);
                npcAnim.Play("Victory");
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

    public void Disable() {
        this.gameObject.SetActive(false);
    }

    public void SetOrder(Order _order) {
        order = _order;
    }
}
