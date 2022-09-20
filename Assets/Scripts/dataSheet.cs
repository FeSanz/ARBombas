using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dataSheet : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    [SerializeField] GameObject pumpOptions;
    [SerializeField] TextMeshProUGUI typeOfPump;
    [SerializeField] TextMeshProUGUI voltage;
    [SerializeField] TextMeshProUGUI power;
    [SerializeField] TextMeshProUGUI stream;
    [SerializeField] TextMeshProUGUI outletPressure;
    [SerializeField] TextMeshProUGUI maximumHeight;
    [SerializeField] TextMeshProUGUI weight;
    [SerializeField] TextMeshProUGUI size;
    [SerializeField] TextMeshProUGUI features;
    [SerializeField] TextMeshProUGUI aplicactions;
    // Start is called before the first frame update
    void Start()
    {
        closeBtn.onClick.AddListener(closePanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void closePanel()
    {
        pumpOptions.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetActive(
        string typeOfPumpT, 
        string voltageT, 
        string powerT,
        string streamT, 
        string outletPressureT,
        string maximumHeightT,  
        string weightT, 
        string sizeT, 
        string featuresT, 
        string aplicactionsT)
    {
        pumpOptions.SetActive(false);
        typeOfPump.SetText(typeOfPumpT);
        voltage.SetText(voltageT);
        power.SetText(powerT);
        stream.SetText(streamT);
        outletPressure.SetText(outletPressureT);
        maximumHeight.SetText(maximumHeightT);
        weight.SetText(weightT);
        size.SetText(sizeT);
        features.SetText(featuresT);
        aplicactions.SetText(aplicactionsT);

        gameObject.SetActive(true);
}
}
