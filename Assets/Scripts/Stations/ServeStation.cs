using UnityEngine;

public class ServeStation : StationBase
{
    public ParticleSystem sparkleFX;
    public int timer;
    public override void Enter() => Debug.Log("Prep Start");

    public override void Action()
    {
        sparkleFX?.Play();
        GameManager.I.AddScore(10);
    }

    public override void Exit() => Debug.Log("Prep Exit");
}
