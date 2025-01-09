using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement))]//ex: typeof(PlayerAudio)
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    public void GetScriptComponents()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
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
}
