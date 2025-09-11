using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public Animator cutsceneCameraAnimator;
    public string introAnimationName = "Intro01";
    private bool cutscenePlaying = true;
    private MonoBehaviour playerController;

    void Start()
    {
        playerController = player.GetComponent<MonoBehaviour>();
        mainCamera.gameObject.SetActive(false);
        playerController.enabled = false;
        timerCanvas.SetActive(false);
        cutsceneCameraAnimator.Play(introAnimationName);
    }

    void Update()
    {
        if (cutscenePlaying && IsCutsceneFinished())
        {
            EndCutscene();
        }

        if (!cutscenePlaying && PlayerHasMoved())
        {
            StartTimer();
            mainCamera.gameObject.SetActive(true);
        }
    }

    private bool IsCutsceneFinished()
    {
        AnimatorStateInfo stateInfo = cutsceneCameraAnimator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(introAnimationName) && stateInfo.normalizedTime >= 1f;
    }

    private void EndCutscene()
    {
        cutscenePlaying = false;
        mainCamera.gameObject.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    private bool PlayerHasMoved()
    {
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    private void StartTimer()
    {
        timerCanvas.SetActive(true);
    }
}
