using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girdSystemsingle : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    public void show() { 
    
    meshRenderer.enabled = true;
    
    }
    public void hide() {
        meshRenderer.enabled = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
