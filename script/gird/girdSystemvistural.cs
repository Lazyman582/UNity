using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class girdSystemvistural : MonoBehaviour
{
    public GameObject girdSVSperfab;
    private girdSystemsingle[,] girdSystemsingle;
    public static girdSystemvistural Instence { get; set; }

    private void Awake()
    {


        if (Instence)
        {
            Destroy(gameObject);
            return;
        }
        Instence = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        girdSystemsingle = new girdSystemsingle[30, 30];

        for (int x = 0; x < 30; x++)
        {
            for (int y = 0; y < 30; y++)
            {

                girdpostion girdpostion = new girdpostion(x, y);
                GameObject gp = Instantiate(girdSVSperfab, new Vector3(girdpostion.x + 0.3f, 0.25f, girdpostion.y - 0.05f) * 30, Quaternion.identity);

                girdSystemsingle[x, y] = gp.GetComponent<girdSystemsingle>();
            }


        }
    }

    public void HideAllgridpostion()
    {
        for (int x = 0; x < 30; x++)
        {
            for (int y = 0; y < 30; y++)
            {
                girdSystemsingle[x, y].hide();
            }
        }
    }

    public void Showgirdpostions(List<girdpostion> girdpostions)
    {

        foreach (girdpostion girdpostion in girdpostions)
        {

            girdSystemsingle[girdpostion.x, girdpostion.y].show();


        }

    }

    void Update()
    {
        UpdateGirdVistual();
    }
    private void UpdateGirdVistual()
    {

        HideAllgridpostion();
        unit selectedunit = UnitAction.Instence.GetUnit();
        if (selectedunit)
        {
            Showgirdpostions(selectedunit.GetMoveaction().GetvalueGridPosition());
        }


        //}
        // Update is called once per frame
       
    }
}
