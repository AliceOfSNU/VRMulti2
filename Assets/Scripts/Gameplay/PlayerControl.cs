using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerControl : NetworkBehaviour
{
    [SerializeField] float walkSpeed = 0.005f;

    [SerializeField] Vector2 defaultPositionRange = new Vector2(-4, 4);

    [SerializeField] NetworkVariable<float> forwardBackPosition = new NetworkVariable<float>();

    [SerializeField] NetworkVariable<float> leftRightPosition = new NetworkVariable<float>();

    //client caching
    float oldForwardBackPosition;
    float oldLeftRightPosition;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(defaultPositionRange.x, defaultPositionRange.y), 0, Random.Range(defaultPositionRange.x, defaultPositionRange.y));
    }

    private void Update()
    {
        if (IsServer)
        {
            UpdateServer();
        }

        if(IsClient && IsOwner)
        {
            UpdateClient();
        }
    }

    //Server가 포지션을 실질적으로 바꿔줌, 근데 networkTransform 이거쓰면되는거아닌가?
    void UpdateServer()
    {
        transform.position = new Vector3(transform.position.x + leftRightPosition.Value, transform.position.y, transform.position.z + forwardBackPosition.Value);
    }

    void UpdateClient()
    {
        float forwarBackward = 0;
        float leftRight = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            forwarBackward += walkSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            forwarBackward -= walkSpeed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftRight -= walkSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            leftRight += walkSpeed;
        }

        if (oldForwardBackPosition != forwarBackward || oldLeftRightPosition != leftRight)
        {
            oldForwardBackPosition = forwarBackward;
            oldLeftRightPosition = leftRight;
            // update the server
            UpdateClinetPositionServerRPC(forwarBackward, leftRight);
        }
    }

    //Server에게 허락을 구하는중
    [ServerRpc]
    public void UpdateClinetPositionServerRPC(float forwarBackward, float leftRight)
    {
        forwardBackPosition.Value = forwarBackward;
        leftRightPosition.Value = leftRight;
    }
}
