using UnityEngine;
using System.Collections;

public class CookStation : StationBase
{
    public ParticleSystem steamFX, fireFX;
    public float cookTime = 3f;
    bool cooking;

    public override void Enter() => Debug.Log("Cook Active");

    public override void Exit()
    {
    }

    public override void Action()
    {
        if (!cooking) StartCoroutine(CookRoutine());
    }

    IEnumerator CookRoutine()
    {
        cooking = true;
        steamFX.Play();
        yield return new WaitForSeconds(cookTime);
        steamFX.Stop();

        Dish d = GameManager.I.currentDish;
        if (d == null)
        {
            Debug.Log("No prepared dish found!");
            cooking = false;
            yield break;
        }

        if (Random.value > 0.8f)
        {
            fireFX.Play();
            GameManager.I.AddScore(-10);
            Debug.Log($"{d.dishName} burnt!");
            GameManager.I.currentDish = null;
        }
        else
        {
            GameManager.I.AddScore(20);
            Debug.Log($"{d.dishName} cooked!");
            // hand over to ServeStation
            FindObjectOfType<ServeStation>().currentDish = d;
        }

        cooking = false;
    }
}
