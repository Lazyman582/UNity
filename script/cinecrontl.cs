using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinecrontl : MonoBehaviour
{
    [Header("Speed")]
    public float speed = 5f;
    public float RotaionSpeed = 100f;
    private float moveHorizontal;
    private float moveVertical;
    private float zoomAount  = 1 ;
    [Header("Camera")]
    [SerializeField] private CinemachineTransposer transposer;
   [SerializeField] private CinemachineVirtualCamera VirtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    // Update is called once per frame
    void Update()
    {

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 InputMoveDir = new Vector3(moveHorizontal,0,moveVertical).normalized;
        Vector3 movevector3 = transform.forward * InputMoveDir.z + transform.right*InputMoveDir.x;

        transform.position += movevector3 * speed * Time.deltaTime;

        Vector3 rotationVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Q)) { rotationVector.y = 1f; }
        if (Input.GetKey(KeyCode.E)) { rotationVector.y = -1f; }

        transform.eulerAngles += rotationVector *  RotaionSpeed * Time.deltaTime;

        Vector3 followOffest = transposer.m_FollowOffset;
        if (Input.mouseScrollDelta.y >0) {
            Debug.LogWarning("1");
            followOffest.y -= zoomAount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {

            followOffest.y += zoomAount;
        }

        transposer.m_FollowOffset = followOffest;
    }
}
