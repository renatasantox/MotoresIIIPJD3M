using UnityEngine;
using System;

public class PlayerObserverManager : MonoBehaviour
{
    public static Action OnCoinCollected;

    public static Action<int> OnCoinCountChanged;

    public static void NotifyCoinCollected()
    {
        OnCoinCollected?.Invoke();
    }

    public static void NotifyCoinCountChanged(int amount)
    {
        OnCoinCountChanged?.Invoke(amount);
    }
}