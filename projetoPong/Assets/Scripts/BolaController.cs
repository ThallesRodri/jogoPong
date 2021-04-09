using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    // Criando a variavel para saber o rigidbody da bola
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;
    public float velocidade = 8f;
    public float limiteHorizontal = 12f;

    // Variável para o som da bola
    public AudioClip boing;

    // Posição da câmera
    public Transform transformCamera;

    // Delay para a bola
    public float delay = 2f;

    // Variável para reiniciar o jogo depois do delay
    public bool jogoIniciado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <=0 && jogoIniciado == false)
        {
            jogoIniciado = true;

            int direcao = Random.Range(0, 4); // Gerar valores aleatórios para a bola

            //iniciando movimento aleatório para bola
            if (direcao == 0)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 1)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 2)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = -velocidade;
            }
            else if (direcao == 3)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = -velocidade;
            }

            meuRB.velocity = minhaVelocidade;
        }

        // Restartando o jogo quando a bola sair da tela
        if(transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            SceneManager.LoadScene("Jogo");
        }
    }

    // Evento de colisão = Som
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, transformCamera.position);
    }
}
