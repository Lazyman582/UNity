using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GirdSystem
{
    public int hight;

    public int width;

    public GameObject game;


    private int cellSize;

    private girdobject[,] girdobjectarray;



    public void Update() {
       
    
    
    
    }
    public GirdSystem(int width1,int hight1,int cellSize1){

        hight = hight1;
        width= width1;
        cellSize = cellSize1;
        girdobjectarray = new girdobject[width,hight];
        for (int x =0;x<width ;x++ ) {

            for (int z = 0; z < hight; z++) {

                girdpostion girdpostion = new girdpostion(x,z);
                girdobjectarray[x, z] = new girdobject(this,girdpostion);
                //Debug.DrawLine(Getword(x,z),Getword(x,z)+Vector3.right*0.2f,Color.white,1000);

            }



        }

       

    }
    
    public Vector3 Getword(girdpostion girdpostion)
    {


        return new Vector3(girdpostion.x, 0, girdpostion.y) * cellSize;

    }


    public girdpostion girdpostion(Vector3 Worldpositon) {


        return new girdpostion(Mathf.RoundToInt(Worldpositon.x/cellSize),Mathf.RoundToInt(Worldpositon.z/cellSize));
    
    
    }

    public void creatgird(GameObject debug) {


        for (int x = 0; x < width; x++)
        {

            for (int z = 0; z < hight; z++)
            {
              
                girdpostion girdpostion = new girdpostion(x,z);

                GameObject gameObjectdebug = GameObject.Instantiate(debug, Getword(girdpostion),Quaternion.identity);
                giedDebugObject giedDebugObject = gameObjectdebug.GetComponent<giedDebugObject>();
                giedDebugObject.SetGridObject(Getgirdobject(girdpostion));
            }



        }
        game = GameObject.Find("DebugObject");
        game.SetActive(false);


    }

    public girdobject Getgirdobject(girdpostion girdpostion) {


        return girdobjectarray[girdpostion.x, girdpostion.y];
    }

    public bool IsValueGridPosition(girdpostion girdpostion) {

        return girdpostion.x >= 0 && girdpostion.y >= 0 && girdpostion.x < width && girdpostion.y < hight;
    
    }
    
    public int GetWidth() {

        Debug.Log(width);
        return width;
    
    }

    public int GetHight() {

        Debug.Log(hight);
        return hight;
    }
}
