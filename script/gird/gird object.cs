using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girdobject : MonoBehaviour
{
    private GirdSystem girdSystem;
    private girdpostion girdpostion;
    private List<unit> unitlist;
    public girdobject(GirdSystem girdSystem1, girdpostion girdpostion1)
    {

        this.girdSystem = girdSystem1;
        this.girdpostion = girdpostion1;
        unitlist = new List<unit>();

    }
    public override string ToString()///��д�Է��ع涨��Tostring
    {
        string unitstring = "";
        foreach (unit unit in unitlist) {


            unitstring = unitstring + unit;
        
        }
        return girdpostion.ToString() + unitstring;
    }


    public void Addunit(unit unit)///��ʼ��
    {

         unitlist.Add(unit);
        

    }

    public void RemoveUnitlist(unit unit) {

        unitlist.Remove(unit);
    
    }

    public List<unit> getunitlist()///��ȡ����
    {

        return unitlist;
    }

    public bool HasAnyUnit() { 
    
    return unitlist.Count > 0;
    }
}
