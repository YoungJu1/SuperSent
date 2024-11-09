using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerArrow;

    public float moveSpeed = 5f;
    private JoyStick joyStick;
    public Animator Ani;
    private bool isMoving;

    private QuestManager QuestManager;

    private void Awake()
    {
        QuestManager = GameObject.Find("Quest").GetComponent<QuestManager>();
    }

    public void Start()
    {
        Ani = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                isMoving = true;
                break;
            case TouchPhase.Ended:
                isMoving = false;
                Ani.SetBool("player_walk", false);
                break;
            case TouchPhase.Moved:
                Ani.SetBool("player_walk", true);
                break;
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
        if(QuestManager.questNum > 2) return;
        var dir = new Vector3(QuestManager.GetTargetPos().x, 0f, QuestManager.GetTargetPos().z);
        playerArrow.transform.LookAt(dir);
    }

    public void SetJoyStick(JoyStick _joyStick)
    {
        joyStick = _joyStick;
    }
}