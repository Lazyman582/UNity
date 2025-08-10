using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitAction : MonoBehaviour
{

    public static UnitAction Instence { get; set; }
    public event EventHandler Onechoose;
    public unit unitI;

    // Start is called before the first frame update

    private void Awake()
    {
        if (Instence!=null) { 
        
        Destroy(gameObject);  
        
        }
        Instence = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (trycontrol()) return;
            if (unitI)
            {
                //unitI.GetMoveaction().move(mousemove.gamemove());
                girdpostion mouseGridpostion = LiveSystem.Instence.GetGirdpostion(mousemove.gamemove());
                if (unitI.GetMoveaction().IsvalueActiongridpostion(mouseGridpostion)) {

                    unitI.GetMoveaction().move(mouseGridpostion);
                
                }
            }
        }


    }
    
    public bool trycontrol()
    {




        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("unit")))
        {

            unitI = hit.transform.GetComponentInChildren<unit>();

            if (unitI)
            {

                Onechoose?.Invoke(this, EventArgs.Empty);
                return true;
            }

            else
            {



                return false;
            }

        }


        else
        {

            return false;
        }





    }
    public unit GetUnit()
    {


        return unitI;


    }


   
}
