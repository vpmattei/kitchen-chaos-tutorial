using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    private ClearCounter clearCounter;
    [SerializeField] GameObject visualGameObject;

    void Awake()
    {
        clearCounter = gameObject.GetComponentInParent<ClearCounter>();
    }

    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (clearCounter == null)
        {
            Debug.LogError("Null reference for the ClearCounter script");
            return;
        }

        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
