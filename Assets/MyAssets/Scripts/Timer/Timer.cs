using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    public float startTime = 500;

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        timerUI.text = ((int)startTime).ToString();

        if (startTime <= 0) {
            FindObjectOfType<MenuManager>().ForceOver("Out of time!");
        }
    }

    public void AddTime(float add) {
        startTime += add;
    }

    public void ReduceTime(float reduce) {
        startTime -= reduce;
    }
}
