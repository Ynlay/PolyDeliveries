using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject interaction;
    private bool interacting = false;

    private Animator npcAnim;

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
                FindObjectOfType<MenuManager>().RemoveLast();
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
}
