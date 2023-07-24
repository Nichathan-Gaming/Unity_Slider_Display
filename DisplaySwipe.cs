using UnityEngine;
using UnityEngine.EventSystems;

public class DisplaySwipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] ScrollController scrollController;

    float startPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = eventData.position.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Left is true, Right is false
        if (startPosition < eventData.position.x)
        {
            //left
            scrollController.OnLeftButtonClick();
        }
        else
        {
            //right
            scrollController.OnRightButtonClick();
        }
    }
}
