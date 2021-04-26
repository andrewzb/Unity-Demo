using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public void Open()
    {
        SetDefaultState();
        ToggleSubscription(true);
        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
        ToggleSubscription(false);
    }

    protected virtual void SetDefaultState()
    {
        // nothing
    }

    protected virtual void ToggleSubscription(bool subscribe)
    {
        // nothing
    }
}
