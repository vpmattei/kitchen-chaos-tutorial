using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Already has a kitchen object!");
            return;
        }

        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetCounterTopPoint();
        transform.position = clearCounter.GetCounterTopPoint().position;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}