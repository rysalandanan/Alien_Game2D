using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Animator animator;
    private static readonly int State = Animator.StringToHash("state");
    private enum CharacterState { idle,walk,shoot,death}

    Player_Movement player_movement;
    
    private void Start()
    {
        player_movement = GetComponent<Player_Movement>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        CharacterState state;
        if(player_movement.IsMoving())
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
