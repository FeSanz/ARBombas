using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class checkCollision : MonoBehaviour
{
    public Material white, red;
    public GameObject planeF;
    public GameObject NotHit;
    private MeshRenderer mesh = null;
    private bool collisioner = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(.04f, .04f, .04f);
        mesh = gameObject.GetComponent<MeshRenderer>();
        gameObject.AddComponent<Rigidbody>().useGravity = false;
        gameObject.AddComponent<BoxCollider>().isTrigger = true;
        gameObject.tag = "planeIndicator";
    }

    public void SetColorRed()
    {
        //NotHit.gameObject.SetActive(true);
        planeF.GetComponent<AnchorInputListenerBehaviour>().enabled = false;
        mesh.material = red;
    }
    public void SetColorWhite()
    {
        //NotHit.gameObject.SetActive(false);
        planeF.GetComponent<AnchorInputListenerBehaviour>().enabled = true;
        mesh.material = white;
    }

    /*
    private void Update()
    {
        if (collisioner)
        {
            NotHit.gameObject.SetActive(true);
        }
        else
        {
            NotHit.gameObject.SetActive(false);
        }
    }*//*
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "bomba")
        {
            NotHit.gameObject.GetComponent<Alerta>().SetActive();
            planeF.GetComponent<AnchorInputListenerBehaviour>().enabled = false;
            collisioner = true;
            mesh.material = red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "bomba")
        {
            NotHit.gameObject.GetComponent<Alerta>().Disable();
            planeF.GetComponent<AnchorInputListenerBehaviour>().enabled = true;
            collisioner = false;
            mesh.material = white;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bomba")
        {
            NotHit.gameObject.GetComponent<Alerta>().SetActive();
            planeF.GetComponent<AnchorInputListenerBehaviour>().enabled = false;
            collisioner = true;
            mesh.material = red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "bomba")
        {
            NotHit.gameObject.GetComponent<Alerta>().Disable();
            planeF.GetComponent<AnchorInputListenerBehaviour>().enabled = true;
            collisioner = false;
            mesh.material = white;
        }
    }*/
}
