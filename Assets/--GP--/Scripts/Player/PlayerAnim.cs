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
        print("Falling");
        Gamemanager.instance.SetCanMove(!fall);
        animator.SetBool("Fall", fall);
    }
}
