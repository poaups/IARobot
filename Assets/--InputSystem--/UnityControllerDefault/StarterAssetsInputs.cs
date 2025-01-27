using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

        private bool isJumpPressed = false;  // Variable interne pour vérifier l'état du saut

        public void OnJump(InputValue value)
        {
            if (value.isPressed && !isJumpPressed)
            {
                // La touche de saut vient juste d'être pressée
                JumpInput(true);
                isJumpPressed = true;  // Empêche de déclencher à nouveau le saut tant que la touche est maintenue
            }
            else if (!value.isPressed)
            {
                // Réinitialisation lorsque la touche est relâchée
                isJumpPressed = false;
                JumpInput(false);
            }
        }

        private void Update()
        {
			print(jump + "ici");
        }

        public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif
		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

        public void JumpInput(bool newJumpState)
        {
            // On met à jour jump avec l'état de la touche
            if (newJumpState)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }
        }


        public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
        public void OnPrintR(InputValue value)
        {
            if (value.isPressed)
            {
                Debug.Log("Action PrintR déclenchée !");
            }
        }
    }
	
}