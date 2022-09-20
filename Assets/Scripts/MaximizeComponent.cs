using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaximizeComponent : MonoBehaviour
{
    MeshCollider meshCollider;
    private bool maximized = false;
    private Vector3 myLocalScale = new Vector3();
    private Vector3 my2LocalScale = new Vector3();
    private void Start()
    {
        gameObject.tag = "expansible";
        //meshCollider.
        myLocalScale = gameObject.transform.localScale;
        my2LocalScale = gameObject.transform.localScale + (myLocalScale/2);
        gameObject.AddComponent<MeshCollider>();
    }
    public void doMoreBig()
    {
        if (maximized)
        {
            normalSize();
        }
        else
        {
            bigSize();
        }
    }
    
    public void normalSize()
    {
        //gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.transform.localScale = myLocalScale;
        maximized = false;
    }

    public void bigSize()
    {
        //gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        gameObject.transform.localScale = my2LocalScale;
        maximized = true;
    }

}
