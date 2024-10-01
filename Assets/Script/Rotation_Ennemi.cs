using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnZAxis : MonoBehaviour
{
    // Vitesse de rotation en degrés par seconde
    public float rotationSpeed = 90f;

    void Update()
    {
        // Calculer la rotation pour ce frame
        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        // Appliquer la rotation sur l'axe Z
        transform.Rotate(0, 0, rotationThisFrame);
    }
}
