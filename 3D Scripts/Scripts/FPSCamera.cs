using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField]private float yOffset, moveDelay, yOffsetCrouched;
    [SerializeField]private float sensitivity, rotationLimit, rotationDelay;
    
    private float mouseX, mouseY;
    private float rotX, rotY;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotX -= mouseY * sensitivity * Time.deltaTime;
        rotY += mouseX * sensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -90, rotationLimit);

        transform.rotation = Quaternion.Euler(rotX,rotY, 0);
        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.Euler(0, rotY,0), rotationDelay * Time.deltaTime);
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + playerTransform.up * (FPSProperties.crouched? yOffsetCrouched : yOffset), moveDelay * Time.deltaTime);
    }
    
}
