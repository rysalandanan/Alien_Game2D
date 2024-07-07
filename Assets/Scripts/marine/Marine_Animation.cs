using UnityEngine;

public class Marine_Animation : MonoBehaviour
{
    Marine_Movement marine_movement;
    private Animator animator;
    private static readonly int State = Animator.StringToHash("state");
    private enum CharacterState { idle,walk,shoot,death}
    private void Start()
    {
        marine_movement = GetComponent<Marine_Movement>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        CharacterState state;
        if(marine_movement.IsMoving())
        {
            state = CharacterState.walk;
        }
        else
        {
            state = CharacterState.idle;
        }
        animator.SetInteger(State,(int)state);
    }
}
