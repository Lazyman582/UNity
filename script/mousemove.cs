using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Device;

public class mousemove : MonoBehaviour
{
    public GameObject a;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        a.transform.position = gamemove();
        Vector3 Z = a.transform.position;

        Z.y = 0;
        a.transform.position = Z;
    }

    public static Vector3 gamemove() {
      
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 发射射线并检测碰撞
       Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("mouse move"));
        
            // 打印碰撞点的世界坐标
            //Debug.Log(hit.point);

            // 将小球移动到碰撞点


        return hit.point;
    
    }

}
