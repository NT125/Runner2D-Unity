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


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            tankData.health = maxHealth; // Iniciando el primer nivel con vida máxima
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Spike")) && !isInvincible)
        {
            TakeDamage();
            StartCoroutine(Invincibility());
        }
    }

    // Función para recibir daño
    private void TakeDamage()
    {
        tankData.health--;

        Debug.Log(tankData.health <= 0);

        if (tankData.health <= 0)
        {
            Debug.Log("Hola");
            gameOverScreen.GetComponent<GameOverScreen>().ShowGameOverScreen();
            Destroy(gameObject);
        }


        Debug.Log("Vidas: " + tankData.health);
    }

    // Función para otorgarle invencibilidad al jugador. Recibe daño y se vuelve invencible por 1 seg, luego deja de ser invencible
    IEnumerator Invincibility()
    {

        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}
