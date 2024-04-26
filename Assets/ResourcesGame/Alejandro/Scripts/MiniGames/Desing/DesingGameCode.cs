using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DesingGameCode : MonoBehaviour
{
    [SerializeField] int MaxFloors;
    int currentFloors;

    [SerializeField] GameObject[] Floors;
    [SerializeField] Button[] Buttons;

    private void Awake()
    {
        this.currentFloors = this.MaxFloors;
    }

    public bool CanActivateFloor() 
    {
        if (this.currentFloors > 0) 
        {
            this.currentFloors--;
            return true;
        } 
        return false;
    }
}
