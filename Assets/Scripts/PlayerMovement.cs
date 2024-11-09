using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private GameObject player;
    private JoyStick joyStick;
    public Animator Ani;
    private bool isMoving;

    public void Start()
    {
        Ani = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isMoving = true;
                    break;
                case TouchPhase.Ended:
                    isMoving = false;
                    // idle 애니메이션
                    Debug.Log("Ended");
                    Ani.SetBool("player_idle", true);
                    Ani.SetBool("player_walk", false);
                    break;
                case TouchPhase.Moved:
                    // move 애니메이션
                    Debug.Log("Moved");
                    Ani.SetBool("player_idle", false);
                    Ani.SetBool("player_walk", true);
                    break;
            }
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;
        var moveX = joyStick.Horizontal * moveSpeed * Time.deltaTime;
        var moveZ = joyStick.Vertical * moveSpeed * Time.deltaTime;

        var movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement, Space.World);
        player.transform.rotation = Quaternion.LookRotation(movement);
    }

    public void SetJoyStick(JoyStick _joyStick)
    {
        joyStick = _joyStick;
    }
}