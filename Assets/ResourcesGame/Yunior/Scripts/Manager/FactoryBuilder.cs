using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
public enum TypePlayer {Avatar,Arena}
public enum TypeParticle { Ricochet, BulletHole }
public class FactoryBuilder : MonoBehaviour
{
	#region Syngleton
	static FactoryBuilder _instance;

	static public bool isActive {
		get {
			return _instance != null;
		}
	}

	static public FactoryBuilder instance {
		get {
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType(typeof(FactoryBuilder)) as FactoryBuilder;

				if (_instance == null)
				{
					GameObject go = new GameObject("FactoryBuilder");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<FactoryBuilder>();
				}
			}
			return _instance;
		}
	}
	#endregion
	//public List<GameObject> SelectallCharacter = new List<GameObject>();
	//static List<string> nameArenaAllCharacter = new List<string>();
	// Start is called before the first frame update
	void Start()
	{
        //foreach (var item in SelectallCharacter)
        //{
        //    nameArenaAllCharacter.Add(item.GetComponent<UICharacter>().nameArena);
        //}

    }

	public GameObject BuilderPlayer(string prefabnameSand, string nickname,Transform spawnTransform)
	{
		
		GameObject player=null;
		//string prefabnameSand = nameArenaAllCharacter[selectPlayer];
		player = PhotonNetwork.Instantiate(Path.Combine("Prefabs/Characters", prefabnameSand), spawnTransform.position, spawnTransform.rotation, 0);
		if (player != null)
		{
			PlayerSetup _PlayerSetup = player.GetComponent<PlayerSetup>();
			player.GetComponent<PhotonView>().Controller.NickName= nickname;
			//_PlayerSetup.indexSelectPlayer = selectPlayer;
		}
		return player;
	}
	public GameObject BuilderParticle(string  type, Vector3 pos, Vector3 nr)
	{
		
		return Instantiate(Resources.Load(Path.Combine("Prefabs/ParticleWeapons",type)) as GameObject,  pos, Quaternion.LookRotation(nr));

	}

}
