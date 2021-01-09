using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HDMMANAGER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(XRSettings.isDeviceActive);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
