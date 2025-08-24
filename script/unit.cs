using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class unit : MonoBehaviour
{
    // Start is called before the first frame update

    private moveaction moveaction;
    private girdpostion girdpostion;
    public BideAction bideAction;

    void Start()
    {
        bideAction = GetComponent<BideAction>();
        moveaction = GetComponent<moveaction>();
        girdpostion = LiveSystem.Instence.GetGirdpostion(transform.position);///获取游戏物体位置
        LiveSystem.Instence.Addunitgirdpostion(girdpostion,this);///将游戏物体位置转换为单格上的一个单元
    } 

    // Update is called once per frame
    void Update()
    {
      
      girdpostion newgirdpostion = LiveSystem.Instence.GetGirdpostion(transform.position);
        if (newgirdpostion != girdpostion) {

            LiveSystem.Instence.Unitmovegirdposition(this, girdpostion, newgirdpostion);
            girdpostion = newgirdpostion;
        }
    }
   public moveaction GetMoveaction() { 
             
        return moveaction; }


    public BideAction GetBideAction() { 
    
    return bideAction;
    }
    public girdpostion GetGirdpostion() { 
    
    
    return girdpostion;
    
    }
    
}
