using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// uGUI toggle button.
/// </summary>
public class ToggleButton : Image, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private Sprite onSprite;
    public Sprite OnSprite
    {
        get { return onSprite; }
        set { onSprite = value; }
    }

    [SerializeField]
    private Sprite offSprite;
    public Sprite OffSprite
    {
        get { return offSprite; }
        set { offSprite = value; }
    }

    [SerializeField]
    private Sprite disabledSprite;
    public Sprite DisabledSprite
    {
        get { return disabledSprite; }
        set { disabledSprite = value; }
    }

    [SerializeField]
    private bool interactable;
    public bool Interactable
    {
        get { return interactable; }
        set
        {
            interactable = value;
            if (value)
                if (isOn)
                    sprite = onSprite;
                else
                    sprite = offSprite;
            else
                sprite = disabledSprite;
        }
    }
    [SerializeField]
    private bool isOn;
    public bool IsOn
    {
        get { return isOn; }
        set { isOn = value; }
    }

    public delegate void ToggleDelegate(bool toggledValue);
    public ToggleDelegate onToggle = delegate { };

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    protected override void Awake() => base.Awake();

    /// <summary>
    /// When tap down.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData) { }

    /// <summary>
    /// When tap up. ( This function has to need IPointerDownHandler of interface. )
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!interactable)
            return;

        // For tap cancel.
        if (eventData.pointerPressRaycast.gameObject == eventData.pointerCurrentRaycast.gameObject)
            Toggle();
    }

    public void OnDrag(PointerEventData eventData){}

    /// <summary>
    /// Toggle button.
    /// </summary>
    public void Toggle()
    {
        isOn = !isOn;

        if (isOn)
            sprite = onSprite;
        else
            sprite = offSprite;
        
        onToggle(isOn);
    }
}
