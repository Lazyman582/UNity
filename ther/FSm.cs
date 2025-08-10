using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum Stat
{
    Idle, chase, React, Attack, Partol
}


[Serializable]
public class parament
{
   
    public int health;

    public float speed ;

    public float time = 3;

    public float chasespeed;

    public Transform target;

    public Transform[] patrolpoints;

    public Transform[] chasepoint;

    public Animator animator;


}
public class FSm : MonoBehaviour
{
  
    public parament parament1;
   
    private AI currentState;
    private Dictionary<Stat,AI> states = new Dictionary<Stat,AI>();
    // Start is called before the first frame update
    void Start()
    {
        states.Add(Stat.Idle,new AIidle(this));
        states.Add(Stat.Partol, new AIpartol(this));
        states.Add(Stat.chase, new AIchase(this));
        states.Add(Stat.Attack, new AIattack(this));
        states.Add(Stat.React, new AIReact(this));
        
        parament1.animator = GetComponent<Animator>();

        TransitionState(Stat.Idle);
    }
    
    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
      
    }

    public void TransitionState(Stat type) {

        if (currentState!=null) {

            currentState.OnExit();
        
        }
        currentState = states[type];
        currentState.OnEnterState();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.CompareTag ( "Player") ){
            Debug.Log("2");
            parament1.target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("2");
        if (other.CompareTag("Player"))
        {
            Debug.Log("12");
            parament1.target = null;
        }
    }

    public void FilpTo(Transform target) {
        if (target!=null) {

            Vector3 dir = target.position - transform.position;


            if (transform.position.x > target.position.x) {

                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
                Debug.DrawLine(transform.position,dir,Color.red);
            }
            else if (transform.position.x < target.position.x) {


                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            }
        }

    }
}

