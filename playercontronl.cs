using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontronl : MonoBehaviour
{
    private float HoriazonOP;
    private float VerctroeOP;
    private float moveSpeed = 1.5f;
    private float jumpSpeed = 5f;
    private Vector3 dir;
    public Animator animator;
    private CharacterController cc;
    public float grivaty;
    public Vector3 veloctiy;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool isGround;
    public bool UI;
    public GameObject game;
    public Transform Looktarget;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

       
    }
    private void FixedUpdate()
    {
       
        Vector3.ClampMagnitude(dir, 8f);
    }


    public void suoding() { 
    //计算出目标方向
    var dir =Looktarget.position - transform.position;
        dir.y = 0;
    //计算出旋转角度
    var roation = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation,roation,5);

        var Inputx = animator.GetFloat("InputX");
        var InputY = animator.GetFloat("InputY");


        Inputx = Mathf.MoveTowards(Inputx,1,1);
        InputY = Mathf.MoveTowards(InputY,1,1);

        animator.SetFloat("InputX", Inputx);
        animator.SetFloat("InputY", InputY);
    }
    // Update is called once per frame
    void Update()
    {

        if (Looktarget != null) { 
        
        suoding();
        
        }

        if (Input.GetKey(KeyCode.LeftShift) && UI)
        {

            animator.SetBool("runing", true);

        }
        else {

            animator.SetBool("runing", false);
        }
        isGround = Physics.CheckSphere(groundCheck.position,checkRadius,groundLayer);
        if (isGround&&veloctiy.y<0)
        {
            veloctiy.y = -1f;
        }
        HoriazonOP = Input.GetAxis("Horizontal");
        VerctroeOP = Input.GetAxis("Vertical");

        if (HoriazonOP != 0 || VerctroeOP != 0)
        {

            UI = true;

        }
        else { 
        
        UI=false;
        }
        dir = transform.forward * VerctroeOP + transform.right * HoriazonOP;

        cc.Move(dir.normalized*Time.deltaTime* moveSpeed);
        if (Input.GetKeyDown(KeyCode.LeftAlt)) { 
        
        moveSpeed -= 1;

        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {

            moveSpeed = 4.5f;
        
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            moveSpeed = 1;

        }
        if (Input.GetKeyUp(KeyCode.LeftAlt)) {

            moveSpeed = 1;
        
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isGround) {

            veloctiy.y = jumpSpeed;
        
        }
      
        veloctiy.y -= grivaty*Time.deltaTime;
        cc.Move(veloctiy*Time.deltaTime);
    }
}
