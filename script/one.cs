using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class one : MonoBehaviour
{
    // Start is called before the first frame update


    public int a = 10;
    public string c = "good";
    public Vector3 e = new Vector3(1, 2, 3);
    public Text text1;
    public GameObject gameObject1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject1.transform.Translate(e*Time.deltaTime);
    }
}
