using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Slider slider;

    [Header("Display Areas")]
    [SerializeField] RectTransform display;
    [SerializeField] Transform contentHolder;

    [Header("Speed of content")]
    [SerializeField] float moveSpeed= 1;

    /// <summary>
    /// The current index being displayed.
    /// </summary>
    int currentIndex = 0;
    /// <summary>
    /// The starting position of the contentHolder
    /// </summary>
    float startXPosition;

    /// <summary>
    /// The number of children in the contentHolder.
    /// </summary>
    int ContentCount
    {
        get
        {
            return contentHolder.childCount;
        }
    }
    /// <summary>
    /// The position that the contentHolder should be at.
    /// </summary>
    float WantedPosition
    {
        get
        {
            return startXPosition - (currentIndex * display.rect.width);
        }
    }

    private void Start()
    {
        slider.maxValue = ContentCount-1;
        startXPosition = contentHolder.position.x;
    }

    void Update()
    {
        Vector3 pos = contentHolder.position;

        if(pos.x != WantedPosition)
        {
            pos.x = Mathf.Lerp(pos.x, WantedPosition, moveSpeed * Time.deltaTime);
            contentHolder.position = pos;
        }
    }

    public void OnLeftButtonClick()
    {
        if(currentIndex > 0)
        {
            currentIndex--;
            OnIndexChange();
        }
    }

    public void OnRightButtonClick()
    {
        if(currentIndex < ContentCount - 1)
        {
            currentIndex++;
            OnIndexChange();
        }
    }

    public void OnSliderChange(float newValue)
    {
        currentIndex = (int) newValue;
        OnIndexChange();
    }

    void OnIndexChange()
    {
        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex < ContentCount-1;

        slider.value = currentIndex;
    }
}
