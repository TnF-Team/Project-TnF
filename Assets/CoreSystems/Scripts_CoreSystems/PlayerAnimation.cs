using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayerAnimationResources))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerAnimationResources playerAnimationResources;
    [SerializeField] private Animator animator;

    public bool IsIdle {  get; private set; }
    public bool IsLeft { get; private set; }
    public bool IsRight { get; private set; }
    public bool IsUp { get; private set; }
    public bool IsDown { get; private set; }

    //Sitdown, Jump, Die, front, Back
    public void InputAnimationValue()
    {
        // 애니메이터의 파라미터 업데이트
        animator.SetBool("IsIdle", IsIdle);
        animator.SetBool("IsMovingLeft", IsLeft);
        animator.SetBool("IsMovingRight", IsRight);
        animator.SetBool("IsMovingUp", IsUp);
        animator.SetBool("IsMovingDown", IsDown);
    }
    public void SetAnimation(PlayerInput _playerInput)
    {
        if (_playerInput == null)
        {
            Debug.LogWarning("Erro: Not PlayerInput");
        }

        IsIdle = !_playerInput.IsMovingLeft && !_playerInput.IsMovingRight && !_playerInput.IsMovingUp && !_playerInput.IsMovingDown;
        IsLeft = _playerInput.IsMovingLeft;
        IsRight = _playerInput.IsMovingRight;
        IsUp = _playerInput.IsMovingUp;
        IsDown = _playerInput.IsMovingDown;

        InputAnimationValue();
    }
    public void ChangeAnimator(int _skinIndex)
    {
        if (Enum.IsDefined(typeof(SkinType), _skinIndex))
        {
            animator = playerAnimationResources.ChangeAnimationNow(_skinIndex);
        }
        else
        {
            Debug.LogWarning("Invalid skin index");
        }
    }
    public void RefreshPlayerAnimation()
    {
        
    }
}
