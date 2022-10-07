using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EGameMode { Host, Client, Server };

public class GameMode : MonoBehaviour
{
    private static GameMode _instance;
    public static GameMode Instance => _instance;
    [SerializeField] private bool _startAsServer = false;
    public EGameMode Mode = EGameMode.Server;
    private void Awake()
    {
        if (_instance == null)
        {
            Debug.Log("Starting GameMode");
            _instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
        {
            //already exists.
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (_startAsServer)
        {
            Debug.Log("Started Server");
            NetworkManager.Singleton.StartServer();
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        
        if (scene.name == "SampleScene")
        {
            // if in Sample Scene, will start game once NetworkManager is ready.
            StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        //skip this frame.
        yield return null;

        if (Mode == EGameMode.Client) NetworkManager.Singleton.StartClient();
        if (Mode == EGameMode.Host) NetworkManager.Singleton.StartHost();
        if (Mode == EGameMode.Server)
        {
            Debug.Log("Started Server");
            NetworkManager.Singleton.StartServer();
        }

    }
    void OnGUI()
    {
        /*
        //editor only!~
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
            if (GUILayout.Button("Server"))
            {
                NetworkManager.Singleton.StartServer();
            }
            if (GUILayout.Button("Host"))
            {
                NetworkManager.Singleton.StartHost();
            }
        }
        GUILayout.EndArea();
        */
    }
}
