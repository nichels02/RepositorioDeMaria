using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using CMF;
using TMPro;
public class PlayerSetup : MonoBehaviour
{
    public TextMeshProUGUI Localnickname;
    public Transform _canvas;

    PhotonView PV;
    public Transform CameraPivot;
    public Transform CameraRoot;
    //public int indexSelectPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
        {
            this.gameObject.tag = "PlayerClone";
            SetLocalNickName(PV.Controller.NickName);
            Destroy(GetComponent<Mover>());
            Destroy(GetComponent<AdvancedWalkerController>());
            Destroy(GetComponent<CharacterKeyboardInput>());
            Destroy(GetComponent<AnimationControl>());
            Destroy(GetComponent<AudioControl>());

            TurnTowardControllerVelocity[] _TurnTowardControllerVelocity = GetComponentsInChildren<TurnTowardControllerVelocity>();
            foreach (var item in _TurnTowardControllerVelocity)
            {
                Destroy(item);
            }

            SmoothPosition[] _SmoothPosition = GetComponentsInChildren<SmoothPosition>();
            foreach (var item in _SmoothPosition)
            {
                Destroy(item);
            }

            SmoothRotation[] _SmoothRotation = GetComponentsInChildren<SmoothRotation>();
            foreach (var item in _SmoothRotation)
            {
                Destroy(item);
            }

            CameraDistanceRaycaster[] _CameraDistanceRaycaster = GetComponentsInChildren<CameraDistanceRaycaster>();
            foreach (var item in _CameraDistanceRaycaster)
            {
                Destroy(item);
            }


            CameraController[] _CameraController = GetComponentsInChildren<CameraController>();
            foreach (var item in _CameraController)
            {
                Destroy(item);
            }

            CameraMouseInput[] _CameraMouseInput = GetComponentsInChildren<CameraMouseInput>();
            foreach (var item in _CameraMouseInput)
            {
                Destroy(item);
            }

            
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(CameraRoot.gameObject);
        }
        else
        {
            this.gameObject.tag = "Player";
            GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
            if ( Camera != null)
            {
                Camera.transform.parent = CameraPivot;
                Camera.transform.localPosition = Vector3.zero;
                Camera.transform.localRotation = Quaternion.identity;
            }
            _canvas.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (!PV.IsMine)
        {
            _canvas.LookAt(Camera.main.transform.position,Vector3.up);
        }
    }
    
    public void SetLocalNickName(string name)
    {
        if (Localnickname != null)
            Localnickname.text = name;
    }
}
