using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class DraggableBehaviour : MonoBehaviour
{
    private Camera cameraObj;
    public Vector3 position,offset;
    private bool draggable;

    private Coroutine draggingCoroutine;
    public UnityEvent startDragEvent,endDragEvent;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("clicked");
            startDragEvent.Invoke();
            draggingCoroutine = StartCoroutine(Dragging());
        }

        if (ctx.canceled)
        {
            endDragEvent.Invoke();
            StopCoroutine(draggingCoroutine);
        }
    }

    public IEnumerator Dragging()
    {
        offset = transform.position - cameraObj.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, cameraObj.WorldToScreenPoint(transform.position).z));
        while (true)
        {
            Vector3 curScreenPoint = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, cameraObj.WorldToScreenPoint(transform.position).z);
            Vector3 curPosition = cameraObj.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition.z = 0;
            transform.position = curPosition;
            yield return new WaitForFixedUpdate();
        }
        // ReSharper disable once IteratorNeverReturns
    }
}