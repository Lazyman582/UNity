using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BideAction : baseAction
{

    private Action action;
    // Start is called before the first frame update
    
    // Update is called once per frame
    protected override void  Awake()
    {
        base.Awake();
    }

    public void Bide(Action bideaction) {

          action = bideaction;
        animator.SetTrigger("Isbaide");
        Invoke("BideEnd", 4.0f);
    }

    public void BideEnd() {

        action();
    
    }

}
