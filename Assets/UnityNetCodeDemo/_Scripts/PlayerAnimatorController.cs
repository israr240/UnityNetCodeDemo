using Unity.Netcode;
using UnityEngine;

public class PlayerAnimatorController : NetworkBehaviour {

    private const string IS_WALKING = "IsWalking";

    [SerializeField] private PlayerMovement player;

    private Animator animator;

    private void Awake() {

        animator = GetComponent<Animator>();
    }

    private void Update() {

        if (!IsOwner) {

            return;
        }

        animator.SetBool(IS_WALKING, player.IsPlayerWalking());
    }

}
