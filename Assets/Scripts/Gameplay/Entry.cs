using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entry : MonoBehaviour
{
    [SerializeField] private Button _clientBtn;
    [SerializeField] private Button _hostBtn;
    [SerializeField] private Vector3 _offset = Vector3.forward * 0.5f;
    void Start()
    {
        this.transform.position = GameplayHelper.Instance.CenterCameraTransform.position + _offset;
        _clientBtn.onClick.AddListener(()=> { SetGameMode(EGameMode.Client); });
        _hostBtn.onClick.AddListener(()=> { SetGameMode(EGameMode.Host); });
    }

    void SetGameMode(EGameMode mode)
    {
        GameMode.Instance.Mode = mode;
        SceneManager.LoadScene("SampleScene");
    }

}
