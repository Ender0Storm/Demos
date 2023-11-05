using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFiller : MonoBehaviour
{
    public GameObject ballPrefab;
    public int ballCount;

    // Start is called before the first frame update
    void Start()
    {
        int offset_x = Mathf.Min(ballCount, 300) / 20;
        int offset_z = ballCount / 600;

        int x = 0;
        int y = 0;
        int z = 0;

        for (int i = 0; i < ballCount; i++)
        {
            y = i % 10;
            x = i % 300 / 10 - offset_x;
            z = i / 300 - offset_z;

            Instantiate(ballPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}
