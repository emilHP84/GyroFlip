using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{
    public Vector3 attitude;
    public Vector3 localAttitude;

    public float attitudeOffset;
    bool started = false;
    public float minAngle, maxAngle;

    void Start()
    {
       // InvokeRepeating("StartGyro", 1f, 1f);
        Invoke("StartGyro", 1f);
    }

    void StartGyro()
    {
        Input.gyro.enabled = true;
        attitudeOffset = Input.gyro.attitude.eulerAngles.z;//- gameObject.transform.localEulerAngles.y;
        minAngle = -45f + attitudeOffset;
        maxAngle = 45f + attitudeOffset;
        if (minAngle>maxAngle)
        {
            float tempMin = minAngle;
            minAngle = maxAngle;
            maxAngle = tempMin;
        }
        started = true;
    }

    void Update()
    {
        if (started== false) return;
        attitude = Input.gyro.attitude.eulerAngles;
        localAttitude = attitude - Vector3.forward * attitudeOffset;

        Gyro();
        Debug.Log(Input.gyro.updateInterval);
    } 
    


    void Gyro()
    {
        localAttitude.z = Mathf.Clamp(localAttitude.z, -45f, 45f);
        gameObject.transform.localEulerAngles = Vector3.up * localAttitude.z;
        Debug.Log(Input.gyro.attitude);
    }
}
