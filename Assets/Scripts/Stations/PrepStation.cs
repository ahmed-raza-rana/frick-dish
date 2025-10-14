using UnityEngine;

public class PrepStation : StationBase {
    public Animator knifeAnim;
    public ParticleSystem chopFX;
    public Transform spawnPoint;
    public GameObject ingredientPrefab;

    public override void Enter() => Debug.Log("Prep Active");
    public override void Exit() { }

    public override void Action() {
        knifeAnim.SetTrigger("Chop");
        chopFX.Play();
        Instantiate(ingredientPrefab, spawnPoint.position, Quaternion.identity);
        GameManager.I.AddScore(10);
    }
}
