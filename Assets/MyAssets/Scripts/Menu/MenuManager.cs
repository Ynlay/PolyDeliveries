using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI uiMenu;

    [Header("Menu options")]
    public Food[] foodOptions;
    [Header("Waypoints")]
    public Transform[] waypointOptions;
    private int lastWaypoint;
    private int index;
    private List<Order> deliveries;

    [Header("Sound")]
    public AudioClip receive;
    public AudioClip remove;
    public AudioClip getHit;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        deliveries = new List<Order>();
        source = GetComponent<AudioSource>();

        foreach(Transform t in waypointOptions) {
            t.gameObject.SetActive(false);
        }
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
            Application.Quit();
        }
    }

    public void AddRandom() {
        if (index < 3) {
            int randomFood = Random.Range(0, foodOptions.Length);
            int randomWaypoint = Random.Range(0, waypointOptions.Length);

            while (randomWaypoint == lastWaypoint) {
                randomWaypoint = Random.Range(0, waypointOptions.Length);
            }

            Order newOrder = new Order(foodOptions[randomFood], waypointOptions[randomWaypoint]);

            uiMenu.text += "\n" + foodOptions[randomFood].foodName;

            waypointOptions[randomWaypoint].gameObject.SetActive(true);
            if (index > 0 && lastWaypoint!=randomWaypoint) {
                waypointOptions[lastWaypoint].gameObject.SetActive(false);
            }   

            deliveries.Add(newOrder);
            index++;

            lastWaypoint = randomWaypoint;

            FindObjectOfType<Timer>().AddTime(10);
            PlayAudioClip(receive);
        }
    }

    public void RemoveLast() {
        if (index > 0) {
            uiMenu.text = "MENU";
            index--;
            deliveries.RemoveAt(index);
            if (index > 0) {
                deliveries[index-1].GetWaypoint().gameObject.SetActive(true);
            }
            foreach(Order order in deliveries) {
                uiMenu.text += "\n" + order.GetFoodName();
            }

            FindObjectOfType<Timer>().AddTime(20);
            PlayAudioClip(remove);
        }
    }

    public void ReceiveHit() {
        PlayAudioClip(getHit);
        foreach(Order order in deliveries) {
            if (order.GetFoodHealth() > 0) {
                order.DamageFood();
            }
        }
    }

    public void PlayAudioClip(AudioClip _clip) {
        source.Stop();
        source.clip = _clip;
        source.Play();
    }
}
