using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvicible = false;
    public float invincibilityFrameDelay = 0.2f;
    public float invincibilityTime = 3f;

    public SpriteRenderer graphics;

    public HealthBar healthBar;

    public static PlayerHealth instance;

    public AudioClip hitSound;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
    }

    public void HealPlayer(int _amount)
    {
        if (currentHealth + _amount >= 100)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += _amount;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int _damage)
    {
        //Quand le joueur n'est pas invincible il peut prendre des dégats
        if (!isInvicible)
        {
            //AudioManager.Instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= _damage;
            healthBar.SetHealth(currentHealth);
            isInvicible = true;
            //Si le joueur est mort
            if (currentHealth <= 0)
            {
                Death();
                return;
            }
            else
            {
                //Les coroutines gèrent le temps d'invincibilité
                StartCoroutine(InvincibilityFrameGraphic());
                StartCoroutine(HandleInvincibilityDelay());
            }

        }
    }

    //Coroutine 1, fais clignoter le joueur
    public IEnumerator InvincibilityFrameGraphic()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFrameDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFrameDelay);
        }
    }

    //Coroutine 2, rend le joueur vulnérable au bout de "InvincibilityTime" secondes
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvicible = false;
    }

    public void Death()
    {
        PlayerMovement.instance.playerRB.velocity = Vector3.zero;
        //PlayerMovement.instance.playerAnimator.SetTrigger("Death");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.playerRB.bodyType = RigidbodyType2D.Kinematic;

        int waveToSave = WaveManager.instance.GetWave(); //Il faudra save toutes les 5 vagues plus tard
        SaveGame.instance.SaveOnGameOver(PlayerExp.instance.exp, waveToSave);


        //PlayerMovement.instance.playerCollider.enabled = false;
        //GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        //PlayerMovement.instance.animator.SetTrigger("Respawn");
        //PlayerMovement.instance.enabled = true;
        //PlayerMovement.instance.RB.bodyType = RigidbodyType2D.Dynamic;
        //PlayerMovement.instance.playerCollider.enabled = true;
        //currentHealth = maxHealth;
        //healthBar.SetHealth(currentHealth);
    }
}