using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotCollider : MonoBehaviour
{
    //public bool collision = false;
    private Vector3 newPosition;
    public GameObject mesh;
    //[SerializeField] GameObject AlertaPanel;
    public void Awake()
    {
        //mesh = GameObject.Find("DefaultIndicator").GetComponent<MeshRenderer>();
        StartCoroutine(findMesh());
    }

    IEnumerator findMesh()
    {
        yield return new WaitForSeconds(.01f);
        mesh = GameObject.FindGameObjectWithTag("planeIndicator");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "planeIndicator")
        {
            //mesh.GetComponent<checkCollision>().SetColorWhite();
            other.gameObject.GetComponent<checkCollision>().SetColorWhite();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "planeIndicator")
        {
            //mesh.GetComponent<checkCollision>().SetColorRed();
            other.gameObject.GetComponent<checkCollision>().SetColorRed();
        }
    }



}
