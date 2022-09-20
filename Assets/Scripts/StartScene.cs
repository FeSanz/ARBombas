using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] private GameObject ExitPanel;
    [SerializeField] private GameObject[] steps;
    [SerializeField] private Button previousBtn, nextBtn;
    private int numStep = 0;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        previousBtn.onClick.AddListener(previousStep);
        nextBtn.onClick.AddListener(nextStep);
        ShowStep();
    }

    public void GoToUTL(string url)
    {
        Application.OpenURL(url);
    }
    public void StartScenePumps()
    {
        SceneManager.LoadScene(1);
    }

    public void nextStep()
    {
        numStep++;
        ShowStep();
    }

    public void previousStep()
    {
        numStep--;
        ShowStep();
    }

    public void ShowStep()
    {
        foreach (GameObject step in steps)
        {
            step.SetActive(false);
        }
        steps[numStep].SetActive(true);

        if (numStep == 0)
        {
            previousBtn.interactable = false;
        }
        else
        {
            previousBtn.interactable = true;
        }

        if (numStep == steps.Length-1)
        {
            nextBtn.interactable = false;
        }
        else
        {
            nextBtn.interactable = true;

        }
    }

    public void LoadExitPanel()
    {
        ExitPanel.SetActive(true);
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
