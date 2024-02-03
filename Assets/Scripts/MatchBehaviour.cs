using UnityEngine;
using UnityEngine.Events;

public class MatchBehaviour : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent,noMatchEvent;
    private void OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDHolderBehaviour>();
        if (tempObj == null) return; 
        var otherId = tempObj.idObj;
        if (idObj == otherId)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
        }
    }
}
