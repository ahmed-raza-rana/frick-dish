using UnityEngine;

public class CookStation : StationBase
{
    public ParticleSystem fireFX;
    public int timer;
    public override void Enter() => Debug.Log("Prep Start");

    public override void Action()
    {
        fireFX?.Play();
        GameManager.I.AddScore(10);
    }

    public override void Exit() => Debug.Log("Prep Exit");
}
