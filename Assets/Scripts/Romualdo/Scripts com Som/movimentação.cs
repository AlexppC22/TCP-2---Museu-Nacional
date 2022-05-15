using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentação : MonoBehaviour
{
    //Segue abaixo o codigo para a movimentação do personagem com os Axis Horizontal e Vertical assim, as variáveis estão explicadas com comentários acima das respectivas

                                                                          
   //________________________________________________________________________________________________________________________________________________________________________//

                                                                                        //VARIÁVEIS//
   //__________________________________________________________________________________________________________________________________________________________________________//
   
    //referencia para character controler para se comunicar com o character controler em si
    public CharacterController Controller;

   
    //Velocidade a qual o player vai Andar
    public float speed = 12f;

    //Variável que armazena a velocidade do corpo
    public Vector3 velocity;
    

    //Essa variavel define a força da gravidade que se aplica encima do jogador
    public float gravity = -9.81f;


    //Essa variavel serve para se comunicar com o objeto "Empty" chamado Ground check, que serve pra saber se a booleana "nochão" recebe falsa ou verdadeira
    public Transform groundCheck;

   //groundDistance se refere ao raio da esfera que vai ser usado para saber se o jogador ta colidindo ou não com o chão, alterar isso significa que ele vai detectar o chão se ele estiver mais
   //baixo ou numa altura maior
    public float groundDistance = 0.4f;


    //serve para saber oque é chão, os objetos que são detectados como chão terão que receber a "Layer" chamada "Ground"
    public LayerMask groundmask;
    

    //Altura em que o jogador pula
    public float JumpHeight = 3.0f;

    //O teste verdadeiro ou falso que diz se o jogador está ou não tocando no chão
    public bool nochão;
    public AudioClip Footstep;
    public AudioSource AudioManage;

    //___________________________________________________________________________________________________________________________________________________//

                                                                                   //MÉTODOS//  
    //_______________________________________________________________________________________________________________________________________________________//





    void Update()
    {
        //Isso cria uma esfera invisivel que checa se o jogador esta encostando no chão ou não através da colisão da esfera com o chão
        nochão = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        //Essa condicional serve para que os valores da velocidade de Y seja "zerada" caso o jogador esteja encostando no chão, isso serve para evitar que a gravidade fique aumentando infinitamente
        if(nochão && velocity.y < 0 )
        {
            velocity.y = -2f;
        }



        //Serve para pegar a tecla ou o analógico horizontal que esta setado na unity
        float x = Input.GetAxis("Horizontal");
        
        //Serve para pegar a tecla ou o analógico vertical que esta setado na unity
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Horizontal") && AudioManage.isPlaying == false && nochão == true)
        {
            AudioManage.PlayOneShot(Footstep);
        }
        if(Input.GetButton("Vertical") && AudioManage.isPlaying == false && nochão == true)
        {
            AudioManage.PlayOneShot(Footstep);
        }


        //Essa linha serve pra usar a camera como referência, ou seja, a frente vai ser aonde a camera ta olhando, assim como as direções esquerda e direita, são referentes a direção em que
        //a camera olha
        Vector3 move = transform.right *x + transform.forward * z;
        

        //Basicamente oque faz o player andar e a velocidade do mesmo pode ser setada por aqui tbm, aqui por exemplo, ta usando a variável que foi declarado la em cima "speed"
        Controller.Move(move * speed * Time.deltaTime);
       

        //essa linha controla a velocidade da variavel da gravidade, basicamente é oque faz a gravidade funcionar e como ela ta funcionando
        velocity.y += gravity * Time.deltaTime;


        //Essa linha é oque aplica a gravidade escrita na linha de cima para atuar encima do jogador
        Controller.Move(velocity * Time.deltaTime);



        //Condicional para saber se o player pode pular ou não
        if(Input.GetButtonDown("Jump") && nochão)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
    }
}
