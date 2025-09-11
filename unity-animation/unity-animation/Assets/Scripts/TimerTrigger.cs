using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && timer != null)
        {
            timer.StartTimer();
            gameObject.SetActive(false);
        }
    }
}
