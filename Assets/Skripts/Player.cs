using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent (typeof(GunController))]

public class Player : LivingEntity
{
    Camera viewCamera;
    public float _moveSpeed = 5f;
    PlayerController _controller;
    GunController _gunController;

    protected override void Start()
    {
        base.Start();
        _controller = GetComponent<PlayerController>();
        _gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

   
    void Update()
    {
        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * _moveSpeed;
        _controller.Move(moveVelocity);

        //look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane grounfPlane = new Plane(Vector3.up, Vector3.zero);
        float reyDistance;

        if(grounfPlane.Raycast(ray, out reyDistance))
        {
            Vector3 point = ray.GetPoint(reyDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            _controller.LookAt(point);
        }

        //Weapon input

        if(Input.GetMouseButton(0))
        {
            _gunController.Shot();
        }
    }
}
