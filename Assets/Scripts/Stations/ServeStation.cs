using UnityEngine;

public class ServeStation : StationBase
{
    public ParticleSystem sparkleFX;
    public OrderManager orderManager;
    public Dish currentDish;

    public override void Enter() => Debug.Log("Serve Active");
    public override void Exit() { }

    public override void Action()
    {
        if (currentDish == null)
        {
            Debug.Log("No dish prepared!");
            return;
        }

        sparkleFX.Play();
        orderManager.CompleteOrder(currentDish);
        currentDish = null;
    }
}
