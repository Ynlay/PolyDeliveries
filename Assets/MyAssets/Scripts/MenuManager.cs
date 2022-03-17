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
    public string[] options;

    [SerializeField]
    private string[] orders;
    private int last;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        orders = new string[3];
        last = 0;
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
        if (last < 3) {
            int random = Random.Range(0, options.Length);
            uiMenu.text += "\n" + options[random];

            orders[last] = options[random];
            last++;
        }
    }
}
