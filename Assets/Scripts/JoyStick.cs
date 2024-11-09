using UnityEngine;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickHandle;
    
    private Vector2 joystickOriginalPosition;
    private Vector2 inputVector;

    private Image joystickBackgroundImg; 
    private Image joystickHandleImg; 
    public float Horizontal => -inputVector.y;
    public float Vertical => inputVector.x;

    private void Awake()
    {
        joystickBackgroundImg = joystickBackground.GetComponent<Image>();
        joystickHandleImg = joystickHandle.GetComponent<Image>();
    }

    private void Start()
    {
        joystickOriginalPosition = joystickHandle.anchoredPosition;
        joystickBackgroundImg.enabled = false;
        joystickHandleImg.enabled = false;
    }

    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                joystickBackgroundImg.enabled = true;
                joystickHandleImg.enabled = true;
                var touchPosition = GetTouchPosition(touch);
                this.transform.position = touchPosition;
                break;
            case TouchPhase.Moved:
                var movedPosition = GetTouchPosition(touch);
                UpdateJoystickPosition(movedPosition);
                break;
            case TouchPhase.Ended:
                joystickBackgroundImg.enabled = false;
                joystickHandleImg.enabled = false;
                inputVector = Vector2.zero;
                joystickHandle.anchoredPosition = joystickOriginalPosition;
                break;
        }
    }
    
    private Vector2 GetTouchPosition(Touch touch)
    {
        return touch.position;
    }
    
    private void UpdateJoystickPosition(Vector2 position)
    {
        var screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, joystickBackground.position);
        var radius = joystickBackground.sizeDelta / 2;
        inputVector = (position - screenPosition) / radius;

        if (inputVector.magnitude > 1.0f)
        {
            inputVector = inputVector.normalized;
        }

        joystickHandle.anchoredPosition = new Vector2(inputVector.x * radius.x, inputVector.y * radius.y);
    }
}