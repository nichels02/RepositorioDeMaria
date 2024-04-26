using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InformativeEvent : MonoBehaviour
{

    [SerializeField] UnityEvent m_MyEvent;
    bool wasUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if ( wasUsed == false && other.CompareTag("Player") ) 
        {
            wasUsed = true;
            m_MyEvent.Invoke();
            Debug.Log("colisiono");
        }
       
    }

    public void TimeToReUse(float seconds) 
    {
        StartCoroutine(reuseTimer(seconds));
    }

    IEnumerator reuseTimer(float s) 
    {
        yield return new WaitForSeconds(s);
        wasUsed = false;
    }

    

    

}
