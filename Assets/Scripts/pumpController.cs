using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pumpController : MonoBehaviour
{
    [Header("Componentes de la bomba")]
    [SerializeField] GameObject assembleGO;
    [SerializeField] GameObject onOffGO;
    [SerializeField] GameObject dataSheet;
    [SerializeField] Animator motor;
    [SerializeField] Material redColor;
    [SerializeField] Material greenColor;
    [SerializeField] Material blueColor;
    [SerializeField] Material whiteColor;
    [SerializeField] GameObject ARCamera;
    [SerializeField] Transform Texts;
    [SerializeField] TextMeshProUGUI text1, text2, text3, text4;
    [SerializeField] GameObject[] Labels;
    [Header("Características de la bomba")]
    [SerializeField] string typeOfPump;
    [SerializeField] string voltage;
    [SerializeField] string power;
    [SerializeField] string stream;
    [SerializeField] string outletPressure;
    [SerializeField] string maximumHeight;
    [SerializeField] string weight;
    [SerializeField] string size;
    [SerializeField] string features;
    [SerializeField] string aplicactions;
    private List<MaximizeComponent> piecesToMaximize = new List<MaximizeComponent>();
    private bool IsChild = false;


    private bool started = false;
    private bool disarmed = false;

    private void Start()
    {
        //OnOff.onClick.AddListener(OnOffMotor);
        ChildsMaximized();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10, -1, QueryTriggerInteraction.Ignore))
            {
                IsOrNotIs(hit.collider.gameObject);
                //print(hit.collider.gameObject.name);
                if (hit.collider.tag == "OnOff")
                {
                    if (IsChild)
                    {
                        OnOffMotor(hit.collider.gameObject);
                    }
                }
                if (hit.collider.tag == "assemble")
                {
                    if (IsChild)
                    {
                        AssembleDisassmble(hit.collider.gameObject);
                    }
                }

                if (disarmed && hit.collider.tag == "expansible")
                {
                    hit.collider.gameObject.GetComponent<MaximizeComponent>().doMoreBig();
                }
            }
        }
        Texts.LookAt(ARCamera.transform);
    }
    private void OnOffMotor(GameObject Boton)
    {
        if (started)
        {
            Boton.GetComponentInChildren<TextMeshProUGUI>().SetText("On");
            DontShowText();
            assembleGO.SetActive(true);
            Boton.GetComponent<Renderer>().material = redColor;
            Boton.transform.localPosition = new Vector3(0,0,0);
            motor.SetBool("state", false);
            started = false;
        }
        else
        {
            Boton.GetComponentInChildren<TextMeshProUGUI>().SetText("Off");
            assembleGO.SetActive(false);
            Boton.GetComponent<Renderer>().material = greenColor;
            Boton.transform.localPosition = new Vector3(0,0,-.5f);
            motor.SetBool("state", true);
            started = true;
        }
    }

    private void AssembleDisassmble(GameObject Boton)
    {
        if (started)
        {
            motor.SetBool("assemble", false);
            Boton.GetComponent<Renderer>().material = redColor;
            Boton.transform.localPosition = new Vector3(0, 0, 0);
            //Labels.SetActive(false);
            foreach(GameObject label in Labels)
            {
                label.SetActive(false);
            }
            /*MaximizeComponent[] allPieces = FindObjectsOfType(typeof(MaximizeComponent)) as MaximizeComponent[];*/
            foreach (MaximizeComponent piece in piecesToMaximize)
            {
                //piece.GetComponent<MaximizeComponent>().normalSize();
                piece.normalSize();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
            }
            onOffGO.SetActive(true);
            disarmed = false;
            started = false;
        }
        else
        {
            motor.SetBool("assemble", true);
            Boton.GetComponent<Renderer>().material = greenColor;
            Boton.transform.localPosition = new Vector3(0, 0, -.5f);
            //Labels.SetActive(true);
            foreach (GameObject label in Labels)
            {
                label.SetActive(true);
            }
            onOffGO.SetActive(false);
            disarmed = true;
            started = true;
        }
    }

    private void IsOrNotIs(GameObject button)
    {
        IsChild = false;
        foreach (Transform child in assembleGO.transform)
        {
            if (child.gameObject == button)
            {
                IsChild = true;
            }
        }
        foreach (Transform child in onOffGO.transform)
        {
            if (child.gameObject == button)
            {
                IsChild = true;
            }
        }
    }
    public void showText1()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
    }
    public void showText2()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(true);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
    }
    public void showText3()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(true);
        text4.gameObject.SetActive(false);
    }
    public void showText4()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(true);
    }

    private void DontShowText()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
    }

    public void OpenDataSheet()
    {
        dataSheet.GetComponent<dataSheet>().SetActive(
            typeOfPump,
            voltage,
            power,
            stream,
            outletPressure,
            maximumHeight,
            weight,
            size,
            features,
            aplicactions);
    }

    private void ChildsMaximized()
    {
        //MaximizeComponent[] allPieces = FindObjectsOfType(typeof(MaximizeComponent)) as MaximizeComponent[];
        foreach (Transform child in gameObject.transform)
        {
            if (child.GetComponent<MaximizeComponent>())
            {
                piecesToMaximize.Add(child.gameObject.GetComponent<MaximizeComponent>());
            }
            foreach (Transform grandchild in child.transform)
            {
                if (grandchild.GetComponent<MaximizeComponent>())
                {
                    piecesToMaximize.Add(grandchild.gameObject.GetComponent<MaximizeComponent>());
                }
                foreach (Transform grandgrandchild in grandchild.transform)
                {
                    if (grandgrandchild.GetComponent<MaximizeComponent>())
                    {
                        piecesToMaximize.Add(grandgrandchild.gameObject.GetComponent<MaximizeComponent>());
                    }
                }
            }
        }
        print("total maximizedPieces: "+piecesToMaximize.Count);
    }
}
