using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    private GirdSystem GirdSystem;
  public GameObject Debuggameobject;
    // Start is called before the first frame update
    void Start()
    {
        GirdSystem = new GirdSystem(30,30,30);
        GirdSystem.creatgird(Debuggameobject);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GirdSystem.girdpostion(mousemove.gamemove()));
    }
}
