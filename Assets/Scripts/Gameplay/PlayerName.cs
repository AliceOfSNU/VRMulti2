using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class PlayerName : NetworkBehaviour
{
    private NetworkVariable<NetworkString> playerName = new NetworkVariable<NetworkString>();

    private bool overlayset;
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            playerName.Value = $"Player{OwnerClientId}"; 
        }
    }

    public void SetOverLay()
    {
        var localPlayOverLay = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        localPlayOverLay.text = playerName.Value;
    }

    private void Update()
    {
        if(!overlayset && !string.IsNullOrEmpty(playerName.Value))
        {
            SetOverLay();
            overlayset = true;
        }
    }
}
