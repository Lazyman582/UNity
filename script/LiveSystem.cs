using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSystem : MonoBehaviour
{   private GirdSystem GirdSystem;
  public GameObject Debuggameobject;
    public static LiveSystem Instence { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        

        if (Instence)
        {
            Destroy(gameObject);
            return;
        }
        Instence = this;

    }

    void Start()
    {
        GirdSystem = new GirdSystem(30, 30, 30);
        GirdSystem.creatgird(Debuggameobject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {

            GetHight();
        }
        //Debug.Log(GirdSystem.girdpostion(mousemove.gamemove()));
    }


    public void Addunitgirdpostion(girdpostion girdpostion,unit unit) {

        girdobject girdobject = GirdSystem.Getgirdobject(girdpostion);
 
        girdobject.Addunit(unit);
    }

    public List<unit> getunitgirdpostion(girdpostion girdpostion) {


        girdobject girdobject = GirdSystem.Getgirdobject(girdpostion);
        return girdobject.getunitlist();
    }


    public void Removeunitpostion(girdpostion girdpostion,unit unit) {
    
    girdobject girdobject = GirdSystem.Getgirdobject(girdpostion);
        girdobject.RemoveUnitlist(unit);

    }

    public girdpostion GetGirdpostion(Vector3 worldpostion) {



        return GirdSystem.girdpostion(worldpostion);
    
    }

    public Vector3 GetWorldpostion(girdpostion girdpostion) {

        return GirdSystem.Getword(girdpostion);
    
    }

    public int GetWidth() {


        return GirdSystem.GetWidth();
    }

    public int GetHight() {

        return GirdSystem.GetHight();
    
    }
    public bool IsValueGridPosition(girdpostion gridpostion)
    {



        return GirdSystem.IsValueGridPosition(gridpostion);

    }
    public void Unitmovegirdposition(unit unit, girdpostion fromgirdpostion, girdpostion Togirdpostion)
    {

        Removeunitpostion(fromgirdpostion,unit);
        Addunitgirdpostion (Togirdpostion,unit);
    }
    public bool HasAnyunitGridposition(girdpostion girdpostion) {


        girdobject girdobject = GirdSystem.Getgirdobject(girdpostion); 
        return girdobject.HasAnyUnit();
    
    }
}
