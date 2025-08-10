using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing1 : MonoBehaviour
{
    public unit unit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {

            girdSystemvistural.Instence.HideAllgridpostion();
            girdSystemvistural.Instence.Showgirdpostions(unit.GetMoveaction().GetvalueGridPosition());
        
        }
    }
}
