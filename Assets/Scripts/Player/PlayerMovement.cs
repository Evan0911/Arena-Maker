using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool isMouseButtonHeld;

    public Rigidbody2D playerRB;
    public Animator playerAnimator;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseButtonHeld = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseButtonHeld = false;
        }

        Movement();
    }

    public void Movement()
    {
        if (isMouseButtonHeld == true)
        {
            //Création d'un Vector3 contenant la distance entre la perso et la souris . ScreenToWorldPoint pour convertir la position de la souris à l'échelle de l'écran (et 0 en z sinon il fait n'imp)
            Vector3 dir = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0) - transform.position;

            //Application du mouvement comme pour le joueur avec une direction normalisé pour convenir aux paramètres demandé et Space World pour un déplacement dans l'espace
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        }
    }
}
