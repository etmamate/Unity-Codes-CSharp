using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity = 100f;
    [SerializeField] public Transform playerBody;

    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locka o mouse no centro da tela
    }
    void Update()
    {
        //Inputs do mouse * sensibilidade * delta time para o framerate;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //Inverte ou não o mouse; "xRotation -= mouseY" == Normal "xRotation += mouseY" == Invertido 
        xRotation -= mouseY;

        //Limita o Angulo de visão do eixo Y
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Adiciona a Rotação nos eixos, no caso somente no eixo X
        transform.localRotation = Quaternion.Euler(xRotation, 0f,0f);
        
        //Rotaciona o personagem no eixo X
        playerBody.Rotate(Vector3.up, mouseX);

    }
}
