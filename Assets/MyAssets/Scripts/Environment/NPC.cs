using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private Animator anim;
    private int index;
    private float timeWaited;
    private bool waiting;
    private float timeToWait = 3.25f;

    [Header("NPC Info")]
    public float speed = 2.0f;
    public bool moving;
    public bool cellphone;
    public bool talking;
    public Transform[] waypoint;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    

        if (cellphone) {
            anim.SetBool("Cellphone", true);
        }

        if (talking) {
            anim.SetBool("Talking", true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moving) {
            // Wait and stop moving
            if (waiting) {
                timeWaited += Time.deltaTime;
                if (timeWaited > timeToWait) {
                    timeWaited = 0;
                    waiting = false;
                } else {
                    waiting = true;
                }
            }

            // Move towards waypoint!
            if (!waiting) {
                transform.LookAt(waypoint[index].position);
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, waypoint[index].position, step);
            }
            
            // Check if NPC has reached the waypoint!
            if (Vector3.Distance(transform.position, waypoint[index].position) < 1f) {
                if (index < waypoint.Length-1) {
                    index++;
                } else {
                    index = 0;
                }
            }
        }

        if (cellphone) {
            anim.SetBool("Cellphone", true);
        }

        if (talking) {
            anim.SetBool("Talking", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            anim.Play("Shoved");
            timeWaited = 0;
            waiting = true;
            FindObjectOfType<MenuManager>().ReceiveHit();
        }
    }
}
