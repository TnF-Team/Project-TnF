using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkinType
{
    Swat,
    GasMask
}
public class PlayerAnimationResources : MonoBehaviour
{
    [SerializeField] List<Animator> animators = new();
    public void ResetSkinStates()
    {
        skinType = SkinType.Swat;
    }
    public SkinType skinType { get; private set; }

    Animator GetAnimatorResources(SkinType skinType)
    {
        return animators[(int)skinType];
    }
    public Animator ChangeAnimationNow(int _skinIndex)
    {
        if (_skinIndex < 0 || _skinIndex >= animators.Count)
        {
            return null;
        }
        return GetAnimatorResources((SkinType)_skinIndex);
    }
}
