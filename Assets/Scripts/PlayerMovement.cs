using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private JoyStick _joyStick;

    [SerializeField] private GameObject player;

    private bool _isMoving;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _isMoving = true;
                    break;
                case TouchPhase.Ended:
                    _isMoving = false;
                    // idle 애니메이션
                    break;
                case TouchPhase.Moved:
                    // move 애니메이션
                    break;
            }
        }
        else
        {
            _isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (!_isMoving) return;
        var moveX = _joyStick.Horizontal * moveSpeed * Time.deltaTime;
        var moveZ = _joyStick.Vertical * moveSpeed * Time.deltaTime;

        var movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement, Space.World);
        player.transform.rotation = Quaternion.LookRotation(movement);
    }

    public void SetJoyStick(JoyStick joyStick)
    {
        _joyStick = joyStick;
    }
}