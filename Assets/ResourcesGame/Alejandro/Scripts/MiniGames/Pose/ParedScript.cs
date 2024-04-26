using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedScript : MonoBehaviour
{
    [SerializeField] pose posePared;

    private void FixedUpdate()
    {
        transform.Translate(0,0,-3*Time.deltaTime);
    }

  
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (posePared == other.gameObject.GetComponent<PersonajePoseScript>().poseActual)
            {
                Debug.Log("BIEN");
            }
            else 
            {
                Debug.Log("MAL");
            }
        }
    }


}
