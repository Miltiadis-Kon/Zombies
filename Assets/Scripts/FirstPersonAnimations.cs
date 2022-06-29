using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif


namespace StarterAssets
{
public class FirstPersonAnimations : MonoBehaviour
{
    public Animator animator;
    public void CheckInput(float _speed,StarterAssetsInputs _input)
    {
			if(_speed > 0) animator.SetBool("walk",true);
            else if(_input.jump) Animator.Play("jump");
            else if(_input.sprint) animator.SetBool("sprint",true);
			else 
            {animator.SetBool("walk",false);
            animator.SetBool("sprint",false);
            } 
    }
}
}