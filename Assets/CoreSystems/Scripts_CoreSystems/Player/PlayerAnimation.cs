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
    public bool IsFront { get; private set; }
    public bool IsBack { get; private set; }
    public bool IsCrouchi { get; private set; }
    public bool IsJump { get; private set; }

    public void InputAnimationValue()
    {
        // 애니메이터의 파라미터 업데이트
        animator.SetBool("IsIdle", IsIdle);
        animator.SetBool("IsMovingLeft", IsLeft);
        animator.SetBool("IsMovingRight", IsRight);
        animator.SetBool("IsMovingFront", IsFront);
        animator.SetBool("IsMovingBack", IsBack);

        animator.SetBool("IsCrouchi", IsCrouchi);
        animator.SetBool("IsJump", IsJump);
    }
    public void SetAnimation(PlayerInput _playerInput)
    {
        if (_playerInput == null)
        {
            Debug.LogWarning("Erro: Not PlayerInput");
        }

        /*IsIdle = !_playerInput.IsMovingLeft && !_playerInput.IsMovingRight && !_playerInput.IsMovingFront && !_playerInput.IsMovingBack;
        IsLeft = _playerInput.IsMovingLeft;
        IsRight = _playerInput.IsMovingRight;
        IsFront = _playerInput.IsMovingFront;
        IsBack = _playerInput.IsMovingBack;*/

        IsCrouchi = _playerInput.IsCKey;
        IsJump = _playerInput.IsSpace;

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
