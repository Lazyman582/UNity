using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitselect : MonoBehaviour
{
    [SerializeField]
    public unit unitII;/// <summary>
                       /// / not unitsleect
                       /// </summary>
    [SerializeField]
    private MeshRenderer Mesh;
    // Start is called before the first frame update
    void Start()
    {
        UnitAction.Instence.Onechoose += OnSelect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnSelect(object sender,EventArgs empty ) {



        if (UnitAction.Instence.GetUnit() == unitII)
        {


            Mesh.enabled = true;

        }
        else { 
        
        Mesh.enabled = false;
        
        }
    }
}
