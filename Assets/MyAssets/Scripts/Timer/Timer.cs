using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    public float startTime = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        timerUI.text = ((int)startTime).ToString();
    }

    public void AddTime(float add) {
        startTime += add;
    }

    public void ReduceTime(float reduce) {
        startTime -= reduce;
    }
}
