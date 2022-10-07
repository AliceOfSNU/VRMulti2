using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ServerOperations : MonoBehaviour
{

    [SerializeField] private Camera _serverCamera;
    // Start is called before the first frame update
    void Start()
    {
        if(NetworkManager.Singleton.IsClient || NetworkManager.Singleton.IsHost)
        {
            //we dont need this anymore
            Destroy(_serverCamera.gameObject);
            Destroy(this.gameObject);
        }
    }

}
