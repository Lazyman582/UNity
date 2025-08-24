using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveaction : baseAction
{
    //[Header("Animator")]
    //public Animator animator;


    [Header("control")]
    public float rotaspeed = 0.75f;
    private float stopDistance = 0.1f;
    public float movespeed = 10f;
    [SerializeField]
    //private unit unit;
    public int maxMoveinstence = 1;
    public Vector3 targetposition;

    public Action action;
    public bool ismoving = false;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        transform.position = targetposition;

    }
    protected override void Start()
    {base.Start();
        unit = GetComponent<unit>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!ismoving == true)
        
            return;
        
        if (Vector3.Distance(transform.position, targetposition) > stopDistance)
        {
            Vector3 movediretion = (targetposition - transform.position).normalized;

            transform.position = transform.position + movediretion * Time.deltaTime * movespeed;

            transform.forward = Vector3.Lerp(transform.forward, movediretion, rotaspeed);



            animator.SetBool("IsMoveing", true);
        }
        else
        {
            ismoving = false;
            animator.SetBool("IsMoveing", false);
            action();
        }
    }
    public void move(girdpostion girdpostion,Action moveaction)
    {ismoving = true;
        action = moveaction;
        targetposition = LiveSystem.Instence.GetWorldpostion(girdpostion);

    }

    public bool IsvalueActiongridpostion(girdpostion girdpostion) {

        List<girdpostion> valueGridpostionlist = GetvalueGridPosition();
    return valueGridpostionlist.Contains(girdpostion);
    }
    public List<girdpostion> GetvalueGridPosition() { 
    
    List<girdpostion> girdpostionslist = new List<girdpostion>();
        girdpostion unitgirdpostion =unit.GetGirdpostion();
        for (int x =-maxMoveinstence; x<=maxMoveinstence ;x++ ) {

            for (int y = -maxMoveinstence; y <= maxMoveinstence; y++) { 
            
            girdpostion offectgridpostion = new girdpostion(x,y);
                girdpostion testgridpostion = unitgirdpostion + offectgridpostion;
                if (!LiveSystem.Instence.IsValueGridPosition(testgridpostion)) {

                    continue;
                }
                
                if (unitgirdpostion == testgridpostion)
                {

                    continue;

                }
                if (LiveSystem.Instence.HasAnyunitGridposition(testgridpostion)) {

                    continue;
                
                }
               
                girdpostionslist.Add(testgridpostion);
             
            }

         
        }

    return girdpostionslist;
    }

  
}
