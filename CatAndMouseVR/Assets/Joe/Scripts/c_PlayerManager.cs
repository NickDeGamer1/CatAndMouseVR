using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class c_PlayerManager : MonoBehaviour
{
    public GameObject[] catSpawnPoints;

    public GameObject[] mouseSpawnPoints;

    public GameObject vrPrefab;
    public GameObject catPrefab;

    public List<PlayerInput> playerList = new List<PlayerInput>();

    [SerializeField]
    InputAction joinAction;
    [SerializeField]
    InputAction leaveAction;

    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;

    // INSTANCES
    public static c_PlayerManager instance = null;

    public c_CatCameras catCams;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != null)
        {
            Destroy(gameObject);
        }

        catSpawnPoints = GameObject.FindGameObjectsWithTag("CatSpawnPoint");
        mouseSpawnPoints = GameObject.FindGameObjectsWithTag("MouseSpawnPoint");

        joinAction.Enable();
        joinAction.performed += context => JoinAction(context);

        leaveAction.Enable();
        leaveAction.performed += context => LeaveAction(context);
    }

    private void Start()
    {
        PlayerInputManager.instance.playerPrefab = vrPrefab;
        PlayerInputManager.instance.JoinPlayer(0, -5, null);
        PlayerInputManager.instance.playerPrefab = catPrefab;
    }

    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerList.Add(playerInput);

        //Transform playerParent = playerInput.transform.parent;
        //playerParent.position = catSpawnPoints[0].transform.position;

        if (PlayerJoinedGame != null)
        {
            PlayerJoinedGame(playerInput);
        }


    }
    void OnPlayerLeft(PlayerInput playerInput)
    {

    }

    void JoinAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);

    }
    void LeaveAction(InputAction.CallbackContext context)
    {
        
    }
}
