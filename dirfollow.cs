using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirfollow : MonoBehaviour
{
    public Camera Camera;
    public float tuansspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerspeed = Camera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, playerspeed, 0),Time.deltaTime);
    }
}
