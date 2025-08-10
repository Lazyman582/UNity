using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class giedDebugObject : MonoBehaviour
{
    private girdobject girdobject;

    public Text text;
    // Start is called before the first frame update

    public void SetGridObject(girdobject girdobject) {


        this.girdobject = girdobject;
    
    
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = girdobject.ToString();
    }
}
