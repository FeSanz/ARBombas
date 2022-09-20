using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class IndicatorBehaviour : MonoBehaviour
{
    private MeshRenderer mesh = null;
    [SerializeField] GameObject PanelNoFounded;
    [SerializeField] GameObject PanelFounded;
    [SerializeField] Material white;
    [SerializeField] Material red;
    [SerializeField] GameObject Alert;
    public static bool groundFound = false;
    void Start()
    {
        mesh = transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>();
        mesh.material = white;
        mesh.gameObject.AddComponent<checkCollision>();
        PanelFounded.SetActive(false);
        mesh.gameObject.GetComponent<checkCollision>().red = red;
        mesh.gameObject.GetComponent<checkCollision>().white = white;
        mesh.gameObject.GetComponent<checkCollision>().NotHit = Alert;
        mesh.gameObject.GetComponent<checkCollision>().planeF = gameObject;
    }

    void Update()
    {
        if (mesh != null)
        {
            if (mesh.enabled == true)
            {
                groundFound = true;
                PanelNoFounded.SetActive(false);
                PanelFounded.SetActive(true);
            }
            else
            {
                groundFound = false;
                PanelNoFounded.SetActive(true);
                PanelFounded.SetActive(false);
            }
        }
        else
        {
            print("Error. Inicador no encontrado");
        }
    }


}
