using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickHandle;
    
    private Vector2 _joystickOriginalPosition;
    private Vector2 _inputVector;

    public float Horizontal => -_inputVector.y;
    public float Vertical => _inputVector.x;

    private void Start()
    {
        _joystickOriginalPosition = joystickHandle.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var position = RectTransformUtility.WorldToScreenPoint(Camera.main, joystickBackground.position);
        var radius = joystickBackground.sizeDelta / 2;
        _inputVector = (eventData.position - position) / radius;

        if (_inputVector.magnitude > 1.0f)
        {
            _inputVector = _inputVector.normalized;
        }

        joystickHandle.anchoredPosition = new Vector2(_inputVector.x * radius.x, _inputVector.y * radius.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = _joystickOriginalPosition;
    }
}