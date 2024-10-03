using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{
    public Vector3 rotationSpeed;
    public static float worldRotation;

    public float attitudeOffset;
    bool started = false;
    public float minAngle, maxAngle;
    public float speed = 1f;

    void Start()
    {
        //invoke 1 seconde apres lancement du jeu
        Invoke("StartGyro", 1f);
    }

    void StartGyro()
    {
        //activation gyroscope
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.01f;
        //l'attitude offset est égale au gyroscope z
        attitudeOffset = Input.gyro.attitude.eulerAngles.z;

        //min et max angle = 45(-45) + l'attitude z
        minAngle = -45f + attitudeOffset;
        maxAngle = 45f + attitudeOffset;

        //si le min est supérieur au max, il interchange leur valeur
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
        //ne s'active qu'a la fin de la fonction StartGyro
        if (started == false) return;

        //l'attitude est égale au gyroscope du telephone
        rotationSpeed = Input.gyro.rotationRateUnbiased;


        //apelle de la fonction gyro
        Gyro();
    } 
    


    void Gyro()
    {
        worldRotation = Mathf.Clamp(worldRotation + rotationSpeed.z * speed, -45f, 45f);

        //l'angle du gameobject est égal a l'axe Y multiplié par l'attitude local z
        //transform.Rotate()
        gameObject.transform.localEulerAngles = Vector3.up *worldRotation;
    }

}
