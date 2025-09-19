using UnityEngine;
using Valve.VR.InteractionSystem;

public class KeyVR : MonoBehaviour
{
    private Throwable throwable;
    private bool collected = false; 

    void Start()
    {
        throwable = GetComponent<Throwable>();
        if (throwable != null)
        {
            throwable.onPickUp.AddListener(OnPickedUp);
        }
    }

    private void OnPickedUp()
    {
        if (collected) return; // ya fue recogida antes
        collected = true;

        // Avisar al KeyManager
        KeyManager keyManager = FindObjectOfType<KeyManager>();
        if (keyManager != null)
        {
            keyManager.CollectKey();
        }

        // Destruir la llave después de un delay
        Destroy(gameObject, 1f);
    }
}
