﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce = 0.2f;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float recoilForce = 2;
    [SerializeField] private float damage = 20;

    private Rigidbody rigidBody;
    private XRGrabInteractable interactableWeapon;

    protected virtual void Awake()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.onSelectEntered.AddListener(PickUpWeapon);
        interactableWeapon.onSelectExited.AddListener(DropWeapon);
        interactableWeapon.onActivate.AddListener(StartShooting);
        interactableWeapon.onDeactivate.AddListener(StopShooting);
    }

    private void PickUpWeapon(XRBaseInteractor interactor)
    {
        
    }

    private void DropWeapon(XRBaseInteractor interactor)
    {
        
    }


    protected virtual void StartShooting(XRBaseInteractor interactor)
    {
        
    }

    protected virtual void StopShooting(XRBaseInteractor interactor)
    {

    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rigidBody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    public float GetDamage()
    {
        return damage;
    }

}
