using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerBehaviour : MonoBehaviour
{
    PhotonView view;

    public bool isReady;

    Rigidbody rb;
    public float energy = 3;
    public float impulse;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(view.IsMine)
        {
            if (energy < 5)
                energy += Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                if (energy >= 1)
                {
                    Impulse();
                }
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began )
                {
                    if (energy >= 1)
                    {
                        Impulse();
                    }
                }

            }
        }
    }

    void Impulse()
    {
        if (view.IsMine)
        {
            energy -= 1;
            rb.AddForce(transform.up * impulse, ForceMode.Impulse);
        }
    }
}
