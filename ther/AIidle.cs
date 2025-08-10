using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIidle : AI
{
    public FSm mananger;
    public parament parament;
    private float timer;
   
    public AIidle(FSm mananger)
    {
        this.mananger = mananger;
        this.parament = mananger.parament1;
    }

    public void OnEnterState() {

        parament.animator.Play("walk");
    }
    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer>=parament.time) {
            mananger.TransitionState(Stat.Partol);
        
        }

        if (parament.target != null) {

            mananger.TransitionState(Stat.chase);
        }

    }
    public void OnExit()
    {
        timer = 0;

    }

}
public class AIpartol : AI
{
    public FSm mananger;
    public parament parament;
    private int patrolpoint;
    public AIpartol(FSm mananger)
    {
        this.mananger = mananger;
        this.parament = mananger.parament1;
    }

    public void OnEnterState()
    {
        parament.animator.Play("run");
    }
    public void OnUpdate()
    {

        if (parament.target != null)
        {

            mananger.TransitionState(Stat.chase);
        }

        mananger.FilpTo(parament.patrolpoints[patrolpoint]);
      
        mananger.transform.position = Vector3.MoveTowards(mananger.transform.position, parament.patrolpoints[patrolpoint].position,parament.speed *Time.deltaTime);
        if (Vector3.Distance(mananger.transform.position, parament.patrolpoints[patrolpoint].position)<0.1f) {

            mananger.TransitionState(Stat.Idle);
        
        }
      

    }
    public void OnExit()
    {
        patrolpoint++;

        if (patrolpoint >= parament.patrolpoints.Length) {

            patrolpoint = 0;
        }

    }

}

public class AIchase : AI
{
    public FSm mananger;
    public parament parament;
    public int partrolpoint;
    public AIchase(FSm mananger)
    {
        this.mananger = mananger;
        this.parament = mananger.parament1;
       
    }

    public void OnEnterState()
    {

        parament.animator.Play("run");


    }
    public void OnUpdate()
    {
        mananger.FilpTo(parament.target);
        if (parament.target || Vector3.Distance(mananger.transform.position, parament.patrolpoints[partrolpoint].transform.position) < 3f)
        {
            mananger.transform.position = Vector3.MoveTowards(mananger.transform.position, parament.target.transform.position, parament.chasespeed * Time.deltaTime);
            

        }

        if (parament.target == null )
        {

            mananger.TransitionState(Stat.Idle);

        }

    }
    public void OnExit()
    {


    }

}
public class AIReact : AI
{
    public FSm mananger;
    public parament parament;

    public AIReact(FSm mananger)
    {
        this.mananger = mananger;
        this.parament = mananger.parament1;
    }

    public void OnEnterState()
    {
      

    }
    public void OnUpdate()
    {


    }
    public void OnExit()
    {


    }

}
public class AIattack : AI
{
    public FSm mananger;
    public parament parament;

    public AIattack(FSm mananger)
    {
        this.mananger = mananger;
        this.parament = mananger.parament1;
    }

    public void OnEnterState()
    {


    }
    public void OnUpdate()
    {


    }
    public void OnExit()
    {


    }

}
