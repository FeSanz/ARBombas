using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class getAnchorVU : MonoBehaviour
{
    private ContentPositioningBehaviour planeFinder;
    private GameObject Anchor;
    // Start is called before the first frame update
    void Start()
    {
        planeFinder = gameObject.GetComponent<ContentPositioningBehaviour>();
    }
}
