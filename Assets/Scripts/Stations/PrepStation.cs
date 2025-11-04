using UnityEngine;

public class PrepStation : StationBase
{
    public Animator knifeAnim;
    public ParticleSystem chopFX;
    public Transform spawnPoint;
    public GameObject ingredientPrefab;

    public override void Enter() => Debug.Log("Prep Active");

    public override void Exit()
    {
    }

    public override void Action()
    {
        knifeAnim.SetTrigger("Chop");
        chopFX.Play();
        GameManager.I.AddScore(10);

        // Choose a random dish from OrderManager
        OrderManager orderMgr = FindObjectOfType<OrderManager>();
        Dish dish = orderMgr.dishLibrary[Random.Range(0, orderMgr.dishLibrary.Length)];
        GameManager.I.currentDish = dish;

        Debug.Log($"Prepared {dish.dishName} — ready to cook!");
    }
}
