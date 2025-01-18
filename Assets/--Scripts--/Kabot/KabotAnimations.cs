using UnityEngine;
using UnityEngine.AI;

public class KabotAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private KabotMovement kabotMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Speed", kabotMovement.Speed);
    }
}
