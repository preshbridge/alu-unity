using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript;
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.Win();
            winCanvas.SetActive(true);
        }
    }
}
