using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;

    public float TimeOffset;
    public Vector3 PosOffset;

    private Vector3 Velocity;
    void Update()
    {
        //Envoie d'un déplacement à la caméra depuis la position initial vers celle du joueur (+ éventuelle offset), vitesse de référence, temps de décalage entre le déplacement et le déplacement de la caméra
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + PosOffset, ref Velocity, TimeOffset);
    }
}
