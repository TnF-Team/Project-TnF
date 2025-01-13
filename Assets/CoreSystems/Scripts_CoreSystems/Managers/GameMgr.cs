using UnityEngine;

public class GameMgr : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] ResourceMgr resourceMgr;

    [Header("Player")]
    Player player;
    PlayerInput playerInput;
    PlayerMovement playerMovement;

    private void Start()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        if (player == null)
        {
            GameObject playerObj = Instantiate(resourceMgr.GetPlayerPrefab(), resourceMgr.tr.position, Quaternion.identity);
            playerObj.GetComponent<Player>().GetScriptComponents();
            player = playerObj.GetComponent<Player>();
            player.RefreshScriptComponents();
            playerInput = player.GetPlayerInput();
            playerMovement = player.GetPlayerMovement();
        }
    }

    private void Update()
    {
        if (playerInput != null)
        {
            if (playerInput.IsRKey)
            {
                Debug.Log("run R Key");
            }
        }
    }
}