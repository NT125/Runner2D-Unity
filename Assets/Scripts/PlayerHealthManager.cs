using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int playerHealth;
    private bool isInvincible = false; // Booleano que servirá para darle un segundo de invulnerabilidad al jugador tras recibir daño

    void Start()
    {
        playerHealth = maxHealth; // Definiendo la salud del jugador al máximo según maxHealth
    }

    private void OnCollisionEnter2D(Collision2D col){
        if ((col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Spike")) && !isInvincible){
            TakeDamage();
            StartCoroutine(Invincibility());
        }
    }

    // Función para recibir daño
    private void TakeDamage(){
        playerHealth--;
        Debug.Log("Vidas: " + playerHealth);
    }

    // Función para otorgarle invencibilidad al jugador. Recibe daño y se vuelve invencible por 1 seg, luego deja de ser invencible
    IEnumerator Invincibility(){

        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}
