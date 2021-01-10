using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardInput : MonoBehaviour
{
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("NameText");
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void GetText() {
        
        txt.GetComponent<TextMeshPro>().text += this.name;
        //txt.GetComponent().text = this.name;

    }
}
