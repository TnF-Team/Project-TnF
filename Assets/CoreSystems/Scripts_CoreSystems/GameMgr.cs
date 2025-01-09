using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    [Header("Player")]
    //[SerializeField] GameObject playerPrefab;
    [SerializeField] Player player;
    PlayerInput playerInput;
    PlayerMovement playerMovement;

    [Header("Test")]
    public Transform tr;

    private void Start()
    {
        if (player == null)
        {
            //player = Instantiate(playerPrefab.GetComponent<Player>(), tr.position, tr.rotation);//Quaternion.identity);
        }
        player.GetScriptComponents();
        player.RefreshScriptComponents();

        playerInput = player.GetPlayerInput();
        playerMovement = player.GetPlayerMovement();
    }
    private void Update()
    {
        //Debug.Log("Update Now");
        if (playerInput.IsRKey)
        {
            Debug.Log("Re loading !!!");
        }
    }
}
