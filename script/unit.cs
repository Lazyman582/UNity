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
        girdpostion = LiveSystem.Instence.GetGirdpostion(transform.position);///��ȡ��Ϸ����λ��
        LiveSystem.Instence.Addunitgirdpostion(girdpostion,this);///����Ϸ����λ��ת��Ϊ�����ϵ�һ����Ԫ
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
