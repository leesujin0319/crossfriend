using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMoveController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    private Rigidbody rigidbody1;

    [SerializeField]
    private Raft raftObj;
    private Transform RaftObjCompare; 

    Vector3 moveRaftOffsetPos = Vector3.zero;

    public EnvMapManager mapManager;

    private void Awake()
    {
        rigidbody1 = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        mapManager.UpdateForwardBackMove((int)this.transform.position.z);

    }
        private void FixedUpdate()
    {
        Move();
        RaftUpdate();
    }

    private void RaftUpdate()
    {
        if(raftObj == null)
        {
            return;
        }

        Vector3 actorPos = raftObj.transform.position + moveRaftOffsetPos;
        this.transform.position = actorPos;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody1.velocity.y;

        rigidbody1.velocity = dir;
        moveRaftOffsetPos += dir;
        mapManager.UpdateForwardBackMove((int)this.transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Raft"))
        {
            raftObj = other.transform.parent.GetComponent<Raft>();
     
            if(RaftObjCompare != null)
            {
                RaftObjCompare = raftObj.transform;
                moveRaftOffsetPos = this.transform.position - raftObj.transform.position;
            }
            return;
        }

        if(other.tag.Contains("Crush"))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Raft") && RaftObjCompare == other.transform.parent)
        {
            RaftObjCompare = null;
            raftObj = null;
            moveRaftOffsetPos = Vector3.zero;
        }
    }

    public void GameOver()
    {

    }
}
