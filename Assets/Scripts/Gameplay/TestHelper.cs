using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Netcode.Extensions;
public class TestHelper : NetworkBehaviour
{
    [SerializeField] Button serverBtn;
    [SerializeField] Button hostBtn;
    [SerializeField] Button clientBtn;


    void Awake()
    {
        serverBtn.onClick.AddListener(() => 
        {
            NetworkManager.Singleton.StartServer();
            
        });
        hostBtn.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        clientBtn.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }
}
