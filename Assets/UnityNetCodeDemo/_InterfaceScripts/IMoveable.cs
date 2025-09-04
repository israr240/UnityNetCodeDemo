using UnityEngine;
public interface IMoveable 
{
    void HandleMovement();
    void HandleMovementServerRpc();
    bool IsPlayerWalking();
    void SavePlayerWalkingState(Vector3 direction);
}
