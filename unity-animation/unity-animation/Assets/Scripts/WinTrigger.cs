using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript;
    public Text timerText;
    public GameObject _winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.Win();
            _winCanvas.SetActive(true);
        }
    }
        
    }
