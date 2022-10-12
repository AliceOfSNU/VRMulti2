using UnityEngine;
using Unity.Netcode;
using Netcode.Extensions;

public class SpawnMonster : NetworkBehaviour
{
    public GameObject spanwMonster;

    [SerializeField] int maxMonsterSpawnCount;

    public Transform spawnPosition;

    [SerializeField] NetworkObjectPool pool;
    [SerializeField] NetworkManager manager;


    void SpawnObject()
    {
        if (!IsServer) return;

        for (int i = 0; i < maxMonsterSpawnCount; i++)
        {
            GameObject go = pool.GetNetworkObject(spanwMonster).gameObject;
            go.transform.position = new Vector3(Random.Range(-5, 6f), 3f, Random.Range(-5, 6f));
            go.GetComponent<NetworkObject>().Spawn();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnObject();
        }
    }

    
}
