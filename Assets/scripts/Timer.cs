using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool IsTimerOn = false;
    public TextMeshProUGUI num;

    void Start()
    {
        IsTimerOn = true;
    }
    void Update()
    {
        if (IsTimerOn)
        {
            if (timeLeft > 0)
            {
                TimeSpan tm = TimeSpan.FromSeconds(timeLeft);
                num.text = Mathf.Round(timeLeft).ToString();
                timeLeft -= Time.deltaTime;

                if (timeLeft <= 0)
                {
                    SceneManager.LoadScene("game");
                    Destroy(num);
                }
            }
            else
            {
                timeLeft = 0;
                IsTimerOn = false;
            }
        }
    }
}
