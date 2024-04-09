using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class NetworkUI : NetworkBehaviour
{
    [SerializeField] private Button buttonHost;
    [SerializeField] private Button buttonClient;
    [SerializeField] private TextMeshProUGUI PlayerCountText;

    private NetworkVariable<int> PlayerNum = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);
    // Update is called once per frame
    void Awake()
    {
        // Add listeners to buttons
        buttonHost.onClick.AddListener(Host);
        buttonClient.onClick.AddListener(Client);
    }
    public void Host()
    {
        // Start hosting a server
        NetworkManager.Singleton.StartHost();
    }
    public void Client()
    {
        // Start as a client
        NetworkManager.Singleton.StartClient();
    }

    void Update()
    {
  
        PlayerCountText.text = "Player : " + PlayerNum.Value.ToString();
        if(!IsServer) return;
        PlayerNum.Value= NetworkManager.Singleton.ConnectedClients.Count;
    }
}
