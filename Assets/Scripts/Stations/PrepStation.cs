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

    // Get current dish
    var dish = GameManager.I.currentDish;
    if (dish == null)
    {
        // fallback if no dish set
        dish = FindObjectOfType<OrderManager>().dishLibrary[0];
        GameManager.I.currentDish = dish;
    }

    // Spawn its raw version
    if (dish.rawPrefab && spawnPoint)
        Instantiate(dish.rawPrefab, spawnPoint.position, Quaternion.identity);

    Debug.Log($"Prepared {dish.dishName} (raw)");
}
}
