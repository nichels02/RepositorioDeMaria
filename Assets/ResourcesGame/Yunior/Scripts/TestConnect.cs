using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

using TMPro;
public class TestConnect : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI versionGame;

    [SerializeField]
    private LobbyMenu _LobbyMenu;

    [SerializeField]
    private CurrentRoomMenu _CurrentRoomMenu;

    [SerializeField]
    private CreateRoomMenu _CreateRoomMenu;

    [SerializeField]
    private PlayerListingsMenu _PlayerListingsMenu;
    
    //[SerializeField]
    //private TextMeshProUGUI _playerName;
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        versionGame.text = "Version: " + MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }
    #region Connect
    public override void OnConnectedToMaster()
    {
        print("Connected to server.");
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        _LobbyMenu._RoomListingsMenu.SetListRoom(roomList);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnect from server for reason " + cause.ToString());
    }
    #endregion

    #region Player
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        _CurrentRoomMenu._PlayerListingsMenu.AddPlayerListing(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        _CurrentRoomMenu._PlayerListingsMenu.DestroyPlayer(otherPlayer);
    }
    public override void OnLeftRoom()
    {
        _CurrentRoomMenu._PlayerListingsMenu.DestroyPlayerListing();
    }
    #endregion

    #region Room
    public override void OnJoinedRoom()
    {
        _LobbyMenu._RoomListingsMenu.DestroyListRoom();

        _CurrentRoomMenu._PlayerListingsMenu.GetCurrentRoomPlayers(PhotonNetwork.CurrentRoom.Players);

        _CurrentRoomMenu._roomName.text = "Nombre de la Sala: " + PhotonNetwork.CurrentRoom.Name + "\n" +
                                          "Nombre del creador: " + PhotonNetwork.NickName + "\n" +
                                          "Maximo Jugadores (" + (int)PhotonNetwork.CurrentRoom.MaxPlayers + ")";

        UIManager.instance.ActiveComponent(ComponentUI.CurrentRoom);
    }
    public override void OnCreatedRoom()
    {
        _CurrentRoomMenu._roomName.text = "Nombre de la Sala: " + PhotonNetwork.CurrentRoom.Name +"\n"+
                                          "Nombre del creador: " + PhotonNetwork.NickName + "\n" +
                                          "Maximo Jugadores (" + (int)PhotonNetwork.CurrentRoom.MaxPlayers + ")";
    }
    public void OnClickCreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)int.Parse(_CreateRoomMenu._countPlayer.text);
        PhotonNetwork.JoinOrCreateRoom(_CreateRoomMenu._roomName.text, options, TypedLobby.Default);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed: " + message);
    }
    #endregion

    public void OnClickComenzar()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (var item in _PlayerListingsMenu._listings)
            {
                if (item.Player != PhotonNetwork.LocalPlayer)
                {
                    if (!item.IsReady)
                        return;
                }
            }
            PhotonNetwork.LoadLevel(1);
        }
        

    }

}
