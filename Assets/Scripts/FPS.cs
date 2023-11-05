using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    Text fpsCount;
    float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        fpsCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.unscaledDeltaTime;
        if (timeElapsed > 0.2f)
        {
            int fps = Mathf.RoundToInt(1 / Time.unscaledDeltaTime);
            fpsCount.text = "FPS: " + fps;
            timeElapsed = 0;
        }
    }
}
