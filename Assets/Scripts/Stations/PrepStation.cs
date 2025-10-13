using UnityEngine;

public class PrepStation : StationBase
{
    public ParticleSystem chopFX;
    public override void Enter() => Debug.Log("Prep Start");

    public override void Action()
    {
        chopFX?.Play();
        GameManager.I.AddScore(10);
    }

    public override void Exit() => Debug.Log("Prep Exit");
}