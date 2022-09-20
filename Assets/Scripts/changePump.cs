using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;
using Image = UnityEngine.UI.Image;

public class changePump : MonoBehaviour
{
    [SerializeField] private GameObject PlaneFinder;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private Button showOptionsBtn;
    [SerializeField] private TextMeshProUGUI tittleTXT;
    [SerializeField] private TextMeshProUGUI alertTxt;
    [SerializeField] private GameObject PumpsOptions;

    [SerializeField] private Image checkImg;
    [SerializeField] private Button pumpBtn;
    [SerializeField] private Button back;
    [SerializeField] private Button reloadBtn;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button orientateBtn;
    private bool showing = false;

    private void Start()
    {
        back.onClick.AddListener(BackScene);
        reloadBtn.onClick.AddListener(ReloadScene);
        exitBtn.onClick.AddListener(ShowExitPanel);
        orientateBtn.onClick.AddListener(orientatePumps);
        showOptionsBtn.onClick.AddListener(ShowPumpOptions);
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void ChangePumptoPlace(AnchorBehaviour anchor)
    {
        PlaneFinder.SetActive(true);
        PlaneFinder.GetComponent<ContentPositioningBehaviour>().AnchorStage = anchor;
        PumpsOptions.SetActive(false);
        showing = false;
    }

    public void enableCheck()
    {
        checkImg.gameObject.SetActive(true);
        showOptionsBtn.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 270); ;
        pumpBtn.interactable = false;
    }

    public void setImg(Image img)
    {
        checkImg = img;
    }

    public void NonInteractableBtn(Button button)
    {
        pumpBtn = button;
        tittleTXT.SetText(button.GetComponentInChildren<TextMeshProUGUI>().text);
        //alertTxt.SetText("La " + button.GetComponentInChildren<TextMeshProUGUI>().text + " fue movida hacia la derecha.");
    }

    public void ShowPumpOptions()
    {
        if (!showing)
        {
            PumpsOptions.SetActive(true);
            showOptionsBtn.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 90); ;
            showing = true;
        }
        else
        {
            PumpsOptions.SetActive(false);
            showOptionsBtn.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 270); ;
            showing = false;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void BackScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowExitPanel()
    {
        exitPanel.SetActive(true);
    }
    public void dontShowExitPanel()
    {
        exitPanel.SetActive(false);
    }

    public void orientatePumps()
    {
        foreach (GameObject bomba in GameObject.FindGameObjectsWithTag("pump"))
        {
            print(bomba.name);
            Transform cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
            //la bomba se orienta hacia la cámara
            bomba.transform.LookAt(-new Vector3(-cam.position.x, 0, -cam.position.z));
            bomba.transform.rotation = Quaternion.Euler(0, bomba.transform.rotation.eulerAngles.y, bomba.transform.rotation.eulerAngles.z);

        }
    }

    public void exitApp()
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