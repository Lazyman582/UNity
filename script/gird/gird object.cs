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
    public override string ToString()///重写以返回规定的Tostring
    {
        string unitstring = "";
        foreach (unit unit in unitlist) {


            unitstring = unitstring + unit;
        
        }
        return girdpostion.ToString() + unitstring;
    }


    public void Addunit(unit unit)///初始化
    {

         unitlist.Add(unit);
        

    }

    public void RemoveUnitlist(unit unit) {

        unitlist.Remove(unit);
    
    }

    public List<unit> getunitlist()///获取方法
    {

        return unitlist;
    }

    public bool HasAnyUnit() { 
    
    return unitlist.Count > 0;
    }
}
