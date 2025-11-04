using UnityEngine;

public class ServeStation : StationBase
{
    public ParticleSystem sparkleFX;
    public OrderManager orderManager;
    public Dish currentDish;
    
    public AudioSource sfxServe;
    public AudioClip serveGood, serveFail;
    
    public Transform spawnPoint;

    public override void Enter() => Debug.Log("Serve Active");
    public override void Exit() { }

    public override void Action()
    {
        if (currentDish == null)
        {
            Debug.Log("No cooked dish to serve!");
            return;
        }
    
        // Spawn visual
        if (currentDish.cookedPrefab && spawnPoint)
            Instantiate(currentDish.cookedPrefab, spawnPoint.position, Quaternion.identity);
    
        sparkleFX.Play();
        orderManager.CompleteOrder(currentDish);
        GameManager.I.AddScore(30);
    
        Debug.Log($"Served {currentDish.dishName}");
        currentDish = null;
        GameManager.I.currentDish = null;
    }
}
