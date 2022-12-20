using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class Interact : MonoBehaviour
{
    public delegate void OnInteract();
    public event OnInteract onInteract;

    bool interacted = false;

    private void OnTriggerStay(Collider other)
    {
        InputSystem.Update();
        if (Keyboard.current.eKey.isPressed && other.CompareTag("Player") && !interacted)
        {
            interacted = true;
            onInteract?.Invoke();
        }
    }

    public IEnumerator ResetInteracted()
    {
        yield return new WaitForSeconds(2);
        interacted = false;
    }
     
}
