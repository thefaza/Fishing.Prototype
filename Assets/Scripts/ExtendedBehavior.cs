using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

// ABSTRACTION
public abstract class ExtendedBehavior : MonoBehaviour
{

    protected T FindObjectInScene<T>(string name)
    {
        return GameObject.Find(name).GetComponent<T>();
    }


    public void StartRepeatingAction(Action action, float interval)
    {
        StartCoroutine(RepeatAction(action, interval));
    }

    // Coroutine to repeat the action
    private IEnumerator RepeatAction(Action action, float interval)
    {
        while (true)
        {
            action?.Invoke();  
            yield return new WaitForSeconds(interval);
        }
    }
    public void StartDelayedAction(Action action, float delay)
    {
        StartCoroutine(ExecuteAfterDelay(action, delay));
    }

    private IEnumerator ExecuteAfterDelay(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke(); 
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}