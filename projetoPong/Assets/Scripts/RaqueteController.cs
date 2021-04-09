using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{    
    private Vector3 posicaoRaquete; //Movimentar raquete no eixo Y
    public float raqueteY;
    private float velocidade = 8f;
    private float limite = 3.46f;

    //identificar player 1
    public bool player1;

    // Criacao de IA
    public bool playerIA = false;

    // Encontrando posição da bola
    public Transform transformBola;
          
    void Start()
    {        
        posicaoRaquete = transform.position; // Posicao inicial da raquete
    }

    void Update()
    {
        // adicionando o eixo Y a variavel posicaoRaquete, atraves de raqueteY
        posicaoRaquete.y = raqueteY;

        // Modificar posicao da raquete
        transform.position = posicaoRaquete;

        // Velocidade multiplicada pelo DeltaTime
        float deltaVelocidade = velocidade * Time.deltaTime;

        // ** CONTROLES **    
        if (!playerIA)
        {
            if (player1) //identificando player 1 
            {
                // Movimento pra cima
                if (Input.GetKey(KeyCode.W))
                {
                    // SE seta para cima for clicada, ele se move
                    raqueteY += deltaVelocidade;
                    
                }

                // Movimento para baixo
                if (Input.GetKey(KeyCode.S))
                {           
                    raqueteY -= deltaVelocidade;
                    
                }
            }
            else
            {   // PLAYER 2
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    playerIA = true;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    raqueteY += deltaVelocidade;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    raqueteY -= deltaVelocidade;
                }
            }
        }
        else{
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) // Fazendo a IA ou o player 2 assumir o controle
            {
                playerIA = false;
            }

            raqueteY = Mathf.Lerp(raqueteY, transformBola.position.y, 0.1f); //IA
        }

        // condição de limite da tela
        if (raqueteY < -limite)
        {
            raqueteY = -limite;
        }

        if (raqueteY > limite)
        {
            raqueteY = limite;
        }
    }
}
