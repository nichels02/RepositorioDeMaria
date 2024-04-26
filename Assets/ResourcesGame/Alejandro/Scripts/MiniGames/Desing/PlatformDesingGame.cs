using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDesingGame : MonoBehaviour
{
    [HideInInspector] public DesingGameCode desingGameCode;

    private void Awake()
    {
        this.desingGameCode = this.GetComponentInParent<DesingGameCode>();
        this.gameObject.SetActive(false);
    }

    

    public void ActivatePlatform() 
    {
        if (desingGameCode.CanActivateFloor()) 
        {
            this.gameObject.SetActive(true);
        }
    }
}
