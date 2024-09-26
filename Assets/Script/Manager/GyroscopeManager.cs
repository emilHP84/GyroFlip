using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{
    
    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Debug.Log(Input.gyro.attitude);
        //transform.rotation = Input.gyro.attitude;
        gameObject.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.z, 0);
    } 
    


}
