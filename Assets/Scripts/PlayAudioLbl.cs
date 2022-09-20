using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioLbl : MonoBehaviour
{
    [SerializeField] Sprite playImg, stopImg;
    private GameObject cam;
    private AudioSource myAudioSource;
    private AudioSource[] allAudioSources;
    private bool play = true;
    private Image myImage;
    // Start is called before the first frame update
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        myAudioSource = gameObject.GetComponent<AudioSource>();
        myImage = gameObject.GetComponentInChildren<Button>().GetComponent<Image>();
        gameObject.GetComponentInChildren<Button>().onClick.AddListener(StartStopAudios);
    }

    // Update is called once per frame
    public void Update()
    {
        //gameObject.transform.forward = -cam.transform.position;
        if (myAudioSource.isPlaying)
        {
            myImage.sprite = stopImg;
        }else
        {

            myImage.sprite = playImg;
        }
    }

    public void StartStopAudios()
    {
        if (play)
        {
            //Detenemos todos los audios
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.Stop();
            }

            myAudioSource.Play();
            play = false;
        }
        else
        {
            myAudioSource.Stop();
            play = true;
        }
    }
}
