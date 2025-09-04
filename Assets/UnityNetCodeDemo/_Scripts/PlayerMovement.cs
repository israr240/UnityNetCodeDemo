using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour , IMoveable , IRotateable
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private bool isServerAuth;
    private bool isWalking = false;

    private void Update() {

        if (!IsOwner) {

            return;
        }

        HandleMovement();
        HandleRotation();
    }

    public void HandleMovement() {

        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {

            inputVector.y = +1;
        }

        if (Input.GetKey(KeyCode.S)) {

            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.A)) {

            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D)) {

            inputVector.x = +1;
            
        }

        inputVector = inputVector.normalized;

        Vector3 movDir = new Vector3(inputVector.x, 0f, inputVector.y);

        SavePlayerWalkingState(movDir);

        transform.position += movDir * movementSpeed * Time.deltaTime;
    }

    [ServerRpc(RequireOwnership = false)]
    public void HandleMovementServerRpc() {

        //Vector2 inputVector = new Vector2(0, 0);

        //if (Input.GetKey(KeyCode.W)) {

        //    inputVector.y = +1;

        //}

        //if (Input.GetKey(KeyCode.S)) {

        //    inputVector.y = -1;
        //}

        //if (Input.GetKey(KeyCode.A)) {

        //    inputVector.x = -1;
        //}

        //if (Input.GetKey(KeyCode.D)) {

        //    inputVector.x = +1;
        //}

        //inputVector = inputVector.normalized;

        //Vector3 movDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //transform.position += movDir * movementSpeed * Time.deltaTime;
    }

    public bool IsPlayerWalking() {
        return  isWalking;
    }

    public void SavePlayerWalkingState(Vector3 movDir) {
        if (movDir == Vector3.zero)
            isWalking = false;
        else
            isWalking = true;
    }

    public void HandleRotation() {

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down.normalized * rotationSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up.normalized * rotationSpeed);
    }
}
