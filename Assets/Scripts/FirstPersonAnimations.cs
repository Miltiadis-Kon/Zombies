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
    public FirstPersonShoot shooter;
    public void CheckInput(float _speed,StarterAssetsInputs _input)
        {
            MoveAnimation(_input);
            
            if(_input.jump) animator.Play("Base Layer.jump", 0, 0.0f);

            ShootAnimation(_input);
            //if (_input.fire) animator.Play("Base Layer.fire", 0, 0.0f); 
        }

        private void ShootAnimation(StarterAssetsInputs _input)
        {
            if (_input.fire) {shooter.isShooting=true; animator.SetBool("fire", true);}
            else{ animator.SetBool("fire", false);shooter.isShooting=false;}
        }
        private void MoveAnimation(StarterAssetsInputs _input)
        {
            if ((_input.move.x != 0 || _input.move.y != 0) && !_input.sprint) {animator.SetBool("walk", true); animator.SetBool("sprint", false); }
            else if ((_input.move.x != 0 || _input.move.y != 0) && _input.sprint) {animator.SetBool("sprint", true); animator.SetBool("walk", false);}
            else {animator.SetBool("walk", false);  animator.SetBool("sprint", false);}
        }
    }
}