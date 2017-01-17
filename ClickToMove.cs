using UnityEngine;
using System.Collections;

public class ClickToMove : Photon.MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    public float walkRange;
    private static Vector3 position;
    private static bool canMove;
    private static bool stopped;

    public Animation anim;
    public AnimationClip run;
    public AnimationClip idle;
    public PhotonView photonView;

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = transform.position;
            stream.Serialize(ref syncPosition);
        }
        else
        {
            stream.Serialize(ref syncPosition);

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncStartPosition = transform.position;
            syncEndPosition = syncPosition;
        }
    }


    // Use this for initialization
    void Start()
    {
        position = transform.position;
        canMove = true;
    }

    public static void SwitchMove(bool move)
    {
        canMove = move;
    }
    public static void StopMove()
    {
        //si no puede moverse, anulo su objetivo
        position = Helper.GetMousePosition();
        stopped = true;
    }
    public static void StopMove(Vector3 newPosition)
    {
        position = newPosition;
        stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.isMine)
            SyncedMovement();
        else
        {
            if (canMove)
            {
                if (Input.GetMouseButtonDown(1)) //right click
                {
                    //Busco posicion del click
                    locatePosition();
                    stopped = false;
                }
                //voy hasta la posición
                if (!stopped)
                {
                    if (Vector3.Distance(transform.position, position) > walkRange)
                    {
                        moveToPosition();
                    }
                    //parado
                    else
                    {
                        //anim.CrossFade(idle.name);
                    }
                    transform.position.Set(transform.position.x, 0f, transform.position.z);
                }
            }
        }

    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            position.x = hit.point.x;
            position.y = hit.point.y;
            position.z = hit.point.z;
        }
    }

    void moveToPosition()
    {
        //moviendo
        Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
        newRotation.z = 0f;
        newRotation.x = 0f;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.fixedDeltaTime * 10);
        controller.SimpleMove(transform.forward * this.speed);

        anim.CrossFade(run.name);
    }
    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;
        transform.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }
}

