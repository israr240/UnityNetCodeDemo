using UnityEngine.UI;
using UnityEngine;
using Unity.Netcode;

public class TestingNetCodeUI : MonoBehaviour {

    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;

    private void Awake() {

        //For Host
        startHostButton.onClick.AddListener(() => {

            Debug.Log("Host");

            NetworkManager.Singleton.StartHost();
            Hide();

        });

        //For Client
        startClientButton.onClick.AddListener(() => {

            Debug.Log("Client");

            NetworkManager.Singleton.StartClient();
            Hide();

        });
    }

    private void Hide() {

        gameObject.SetActive(false);
    }
}
