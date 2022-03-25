using UnityEngine;

namespace Main.Scripts
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int WaveTrigger = Animator.StringToHash("wave");
        private static readonly int PickupTrigger = Animator.StringToHash("pickup");
        private static readonly int JumpTrigger = Animator.StringToHash("jump");
        private static readonly int WalkBool = Animator.StringToHash("walk");
        private static readonly int RunBool = Animator.StringToHash("run");

        public void Wave()
        {
            animator.SetBool(RunBool, false);
            animator.SetBool(WalkBool, false);
            animator.SetTrigger(WaveTrigger);
        }

        public void Pickup()
        {
            animator.SetBool(RunBool, false);
            animator.SetBool(WalkBool, false);
            animator.SetTrigger(PickupTrigger);
        }

        public void Jump()
        {
            animator.SetBool(RunBool, false);
            animator.SetBool(WalkBool, false);
            animator.SetTrigger(JumpTrigger);
        }

        public void Walk()
        {
            animator.SetBool(RunBool, false);
            animator.SetBool(WalkBool, true);
        }
        
        public void Run()
        {
            animator.SetBool(WalkBool, false);
            animator.SetBool(RunBool, true);
        }
    }
}
