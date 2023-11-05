using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COUNT : MonoBehaviour
{
    public TableFiller filler;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Ball count: " + filler.ballCount;
    }
}
