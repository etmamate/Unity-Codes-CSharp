using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMoviment : MonoBehaviour
{
    [SerializeField] private float speed;
    [HideInInspector] public float inputX, inputZ;
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(inputX, 0, inputZ) * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.C))
        {
            FPSProperties.crouched = !FPSProperties.crouched;
        }
    }
}
