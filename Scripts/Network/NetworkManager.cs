using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    const string VERSION = "v0.0.1";
    public string roomName = "mainRoom";

    private string playerPrefabName = "Prefabs/Characters/MainCharacter";
    private string guiPrefabName = "Prefabs/Characters/GUI";


    public GameObject spawnPoint;

	void Start ()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);
	}

    void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            isVisible = false,
            maxPlayers = 2
        };

        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefabName, spawnPoint.transform.position, spawnPoint.transform.rotation, 0);
        PhotonNetwork.Instantiate(guiPrefabName, spawnPoint.transform.position, spawnPoint.transform.rotation, 0);

    }
}
