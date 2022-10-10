using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayHelper : MonoBehaviour
{
    private static GameplayHelper _instance;
    public static GameplayHelper Instance => _instance;

    [SerializeField] private Transform _centerCameraTransform;
    public Transform CenterCameraTransform { get => _centerCameraTransform; }

    [SerializeField] private GameObject _ovrController;
    public GameObject OVRController { get => _ovrController; }


    void Awake()
    {
        if(_instance == null) _instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
