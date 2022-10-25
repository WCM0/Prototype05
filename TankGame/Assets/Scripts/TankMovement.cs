using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{


    public float tankSpeed = 10f;

    public float _turnSpeed = 180f;

    public float turretRotateSpeed = 500;

    public Transform turret;

    public Transform _emitPoint;

    public Rigidbody _bullet;

    public float _fireSpeed;

    public Transform _turretRotatePoint;

    float currentRotation;

    public GameObject _tank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float accel = Input.GetAxisRaw("Vertical") * tankSpeed * Time.deltaTime;
        _tank.transform.Translate(0, 0, accel);

        float turn = Input.GetAxisRaw("Horizontal");
        _tank.transform.Rotate(0, turn * _turnSpeed * Time.deltaTime, 0);

        float mousePos = Input.GetAxisRaw("Mouse X") * turretRotateSpeed * Time.deltaTime;
        turret.transform.Rotate(0, mousePos, 0, Space.Self);

      
       // float turretVert = Input.GetAxisRaw("Mouse Y");
        // _turretRotatePoint.Rotate(turretVert * turretRotateSpeed * Time.deltaTime, 0, 0);







        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }


    }


  

    void Fire()
    {
        Rigidbody clone;
        clone = Instantiate(_bullet, _emitPoint.position, Quaternion.identity);
        clone.velocity = transform.TransformDirection(_emitPoint.forward * _fireSpeed * Time.deltaTime);
    }


}
