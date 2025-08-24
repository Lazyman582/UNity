using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class baseAction : MonoBehaviour
{
    protected Animator animator;
    protected unit unit;

    // Start is called before the first frame update
    

    
    // Update is called once per frame
   protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        unit = GetComponent<unit>();  
    }

    protected virtual void Start() { 
    
    
    
    }

    protected virtual void Update()
    {



    }
 
}
