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

        // �������߲������ײ
       Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("mouse move"));
        
            // ��ӡ��ײ�����������
            //Debug.Log(hit.point);

            // ��С���ƶ�����ײ��


        return hit.point;
    
    }

}
