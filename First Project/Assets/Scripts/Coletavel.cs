using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public int pontos = 1; // Pontos que o jogador ganha ao coletar o item

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Adicionar pontos após coletar a moeda
            //GameManager.AdicionarPontos(pontos);

            // Destruir o coletável após ser coletado
            Destroy(gameObject);
        }
    }
}