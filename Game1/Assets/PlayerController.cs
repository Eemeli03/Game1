using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    private CharacterController Controller;
    public float PlayerSpeed = 7f;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }

    private void Start()
    {
        Controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Controller.Move(move * PlayerSpeed * Time.deltaTime);
    }
}
