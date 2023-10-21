using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.18f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float jumpHeight = 3f;
    bool isGrounded;
    bool running;
    Vector3 velocity;

    void Update()
    {
        //Cria uma esfera envolta do Objeto Groundcheck e verifica se esta no chão ou não
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Se o player estiver encostando no chão = velocidade vertical é zerada e força o personagem no chão
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Movimentação baseado no eixo Z
        //Inputs do teclado
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Adiciona o input em cada transform
        Vector3 move = transform.right * x + transform.forward * z;

        //Adiciona o move no controller mais o speed
        controller.Move(move * speed * Time.deltaTime);

        //Gravidade
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        //Corrida
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            running = true;
            if (running)
            {
                speed += 5f;
            }

        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        
        //Debug.Log(speed);
    }
}
