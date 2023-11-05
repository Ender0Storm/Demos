using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TableColorChanger : NetworkBehaviour
{
    public MeshRenderer groundMesh;
    Material groundMat;
    NetworkVariable<Color32> tableColor = new NetworkVariable<Color32>(new Color32(52, 84, 45, 255));

    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        print("HI");
        groundMat = groundMesh.material;
        tableColor.OnValueChanged += ChangeColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsClient && Input.GetKeyDown("h"))
        {
            NetworkManager.Singleton.StartHost();
        }
        if (!IsClient && Input.GetKeyDown("c"))
        {
            NetworkManager.Singleton.StartClient();
        }

        if (!IsServer) return;

        if (Input.GetMouseButtonDown(1))
        {
            tableColor.Value = Random.ColorHSV();
        }
    }

    private void ChangeColor(Color32 previousColor, Color32 newColor)
    {
        groundMat.color = newColor;
    }
}
