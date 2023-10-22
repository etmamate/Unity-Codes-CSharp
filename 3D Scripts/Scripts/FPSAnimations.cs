using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAnimations : MonoBehaviour
{
    private Animator anim;
    private FPSMoviment fpsMoviment;
    private FPSGunController gunController;

    void Start()
    {
        anim = GetComponent<Animator>();
        fpsMoviment = GetComponent<FPSMoviment>();
        gunController = GetComponent<FPSGunController>();
    }

    void Update()
    {
        anim.SetFloat("Horizontal", fpsMoviment.inputX);
        anim.SetFloat("Vertical", fpsMoviment.inputZ);
        anim.SetBool("Crouched", FPSProperties.crouched);

        if(gunController.currentWeapon != null)
            gunController.currentWeapon.animator.SetBool("Walk", fpsMoviment.inputX != 0 || fpsMoviment.inputZ != 0);
    }
    public void ToFire()
    {
        gunController.currentWeapon.animator.SetTrigger("Fire");
    }

    public void ToFireAutomatic(bool pressing)
    {
        gunController.currentWeapon.animator.SetBool("Fire", pressing);
    }

    public void ToReload()
    {
        gunController.currentWeapon.animator.SetTrigger("Reload");
    }
}
