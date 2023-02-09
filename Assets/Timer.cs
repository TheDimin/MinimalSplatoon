using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private GameObject CountdownAsset;
    private float totaltime = 60f;
    private int minutes = 0;
    private int seconds = 0;
    private float initializationTime;

    void Start()
    {
        initializationTime = Time.timeSinceLevelLoad;
    }
    private void Timing()
    {
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;

        minutes = Mathf.FloorToInt(totaltime / 60f);
        seconds = Mathf.FloorToInt(totaltime % 60f);
        CountdownAsset.GetComponent<TMPro.TextMeshProUGUI>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
        if (totaltime > 0f)
        {
            totaltime = 60f - timeSinceInitialization;
        }
        else
        {
            //Replace with winner text
            CountdownAsset.GetComponent<TMPro.TextMeshProUGUI>().text = "End!";
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timing();
    }
}