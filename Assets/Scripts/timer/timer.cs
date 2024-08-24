using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTime;

    [SerializeField] private float timeValue;
    void Start()
    {
        InvokeRepeating("DecreaseTime", 1f, 1f);

        
    }
    private void DecreaseTime()
    {
        if (timeValue < 0f) return;

        if(timeValue > 0f)
        {
            timeValue--;
        }

        else
        {
            timeValue = 0f;
        }

        DisplayTime(timeValue);
       
        
    }


    private void IncreaseTime()
    {
        if (timeValue < 0f) return;

        timeValue++;

        DisplayTime(timeValue);
    }
    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0f)
        {
            timeToDisplay = 0f;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);


        txtTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


  
}
