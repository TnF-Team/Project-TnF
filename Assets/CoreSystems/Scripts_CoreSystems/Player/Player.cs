using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement), typeof(PlayerStats))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerStats playerStats;
    public void GetScriptComponents()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerStats = GetComponent<PlayerStats>();
    }
    public void RefreshScriptComponents()
    {
        playerInput.RefreshInputStates();
    }

    public PlayerInput GetPlayerInput()
    {
        return playerInput;
    }
    public PlayerMovement GetPlayerMovement()
    {
        return playerMovement;
    }
    public PlayerStats GetPlayerStats()
    {
        return playerStats;
    }
}
