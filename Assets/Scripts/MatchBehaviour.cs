using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehaviour : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent,noMatchEvent,noMatchDelayedEvent;
    private IEnumerator OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDHolderBehaviour>();
        if (tempObj == null) yield break; 
        var otherId = tempObj.idObj;
        if (idObj == otherId)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
            yield return new WaitForSeconds(1f);
            noMatchDelayedEvent.Invoke();
        }
    }
}
