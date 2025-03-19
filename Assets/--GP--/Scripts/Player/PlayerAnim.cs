using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Falling(bool fall)
    {
        Gamemanager.instance.SetCanMove(!fall);
        animator.SetBool("Fall", fall);
    }

    public void SetAnimFence(bool fence)
    {
        Gamemanager.instance.SetCanMove(!fence);
        animator.SetBool("Fence", fence);
    }
}
