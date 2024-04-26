using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using TMPro;
public class SandController : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
	#region Syngleton
	static SandController _instance;

	static public bool isActive {
		get {
			return _instance != null;
		}
	}

	static public SandController instance {
		get {
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType(typeof(SandController)) as SandController;

				if (_instance == null)
				{
					GameObject go = new GameObject("SandController");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<SandController>();
				}
			}
			return _instance;
		}
	}
	#endregion
	#region UI
	public TextMeshProUGUI UINickName;
	#endregion
	#region Room Info
	public List<Transform> spawnPointRoom = new List<Transform>();

	#endregion
	#region Player Info
	int myNumberInRoom;

	#endregion
	void Awake()
	{

	}
	void Start()
	{
		//GameObject player = GameObject.FindGameObjectWithTag("Player");
		//GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
		//if (player!=null&& Camera!=null)
		//{
		//	Camera.transform.parent = player.GetComponent<PlayerSetup>().CameraPivot;
		//	Camera.transform.localPosition = Vector3.zero;
		//	Camera.transform.localRotation = Quaternion.identity;
		//}
		
	}
	public override void OnEnable()
	{
		PhotonNetwork.AddCallbackTarget(this);
		SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}

	private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		int indexspawnPoint = UnityEngine.Random.Range(0, spawnPointRoom.Count - 1);
		Transform spawnTransform = spawnPointRoom[indexspawnPoint];
		UINickName.text = "NickName: "+PhotonNetwork.NickName;
		FactoryBuilder.instance.BuilderPlayer(PlayerInfo.instance.Selectedcharacter, PhotonNetwork.NickName, spawnTransform);
		print("OnSceneFinishedLoading...");

	}

	public Transform SpawnerPlayer()
	{
		int indexspawnPoint = UnityEngine.Random.Range(0, spawnPointRoom.Count - 1);
		Transform spawnTransform = spawnPointRoom[indexspawnPoint];
		return spawnTransform;
	}
	public override void OnDisable()
	{
		PhotonNetwork.RemoveCallbackTarget(this);
		SceneManager.sceneLoaded -= OnSceneFinishedLoading;
	}
	public void OnSalirButtonClicked()
	{
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.LoadLevel(0);
	}

	void FixedUpdate()
	{
		//if (PhotonNetwork.CurrentRoom != null)
		//{
		//	myNumberInRoom = PhotonNetwork.CurrentRoom.PlayerCount;
		//	if (TextCantidadPlayer != null)
		//		TextCantidadPlayer.text = "countPlayers(" + myNumberInRoom + ") / MaxPlayers (" + PhotonNetwork.CurrentRoom.MaxPlayers + ")";
		//}
	}

	private void OnDrawGizmos()
	{
		foreach (var item in spawnPointRoom)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(item.position, 0.3f);
		}
	}
}
