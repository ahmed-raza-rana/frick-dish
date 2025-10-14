using UnityEngine;
using System.Collections;

public class CookStation : StationBase {
    public ParticleSystem steamFX, fireFX;
    public float cookTime = 3f;
    bool cooking;

    public override void Enter() => Debug.Log("Cook Active");
    public override void Exit() { }

    public override void Action() {
        if(!cooking) StartCoroutine(CookRoutine());
    }

    IEnumerator CookRoutine(){
        cooking = true;
        steamFX.Play();
        yield return new WaitForSeconds(cookTime);
        steamFX.Stop();
        if(Random.value > 0.8f){ // overcooked
            fireFX.Play();
            GameManager.I.AddScore(-10);
        } else {
            GameManager.I.AddScore(20);
        }
        cooking = false;
    }
}
