using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public TankData tankData; // Scriptable Obj
    public GameObject gameOverScreen;
    private bool isInvincible = false; // Booleano que servirá para darle un segundo de invulnerabilidad al jugador tras recibir daño
    private SpriteRenderer playerSprite;

    //Declarando sprites para modificar el contador de vidas del HUD
    public SpriteRenderer healthUI_SR;
    public Sprite health3Sprite; public Sprite health2Sprite; public Sprite health1Sprite; public Sprite health0Sprite;

    void Start()
    {
        healthUI_SR.sprite = health3Sprite;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            tankData.health = maxHealth; // Iniciando el primer nivel con vida máxima
        }
    }

    void Update()
    {
        switch (tankData.health)
        {
            case 2:
                healthUI_SR.sprite = health2Sprite; break;
            case 1:
                healthUI_SR.sprite = health1Sprite; break;
            default:
                healthUI_SR.sprite = health3Sprite; break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Spike")) && !isInvincible)
        {
            TakeDamage();
            StartCoroutine(Invincibility());
            StartCoroutine(InvincibilityFX());
        }
    }

    // Función para recibir daño
    private void TakeDamage()
    {
        tankData.health--;

        if (tankData.health <= 0)
        {
            healthUI_SR.sprite = health0Sprite;
            gameOverScreen.GetComponent<GameOverScreen>().ShowGameOverScreen();
            Destroy(gameObject);
        }

    }

    // Función para otorgarle invencibilidad al jugador. Recibe daño y se vuelve invencible por 1 seg, luego deja de ser invencible
    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }

    // Corrutina para dar un efecto que indique que es invulnerable por un momento al recibir daño
    IEnumerator InvincibilityFX()
    {
        playerSprite.color = new Color(1f, 0.5f, 0.5f, 0.8f); // Seteando un color semi-transparente
        yield return new WaitForSeconds(1f);
        playerSprite.color = Color.white;
    }
}
