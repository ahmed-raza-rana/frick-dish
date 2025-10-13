using UnityEngine;

public class StationNavigator : MonoBehaviour
{
    public GameObject[] stations;
    int index = 0;

    void Start() => Activate(0);

    public void Next() => Switch(1);
    public void Prev() => Switch(-1);

    void Switch(int dir)
    {
        stations[index].SetActive(false);
        index = Mathf.Clamp(index + dir, 0, stations.Length - 1);
        Activate(index);
    }

    void Activate(int i)
    {
        stations[i].SetActive(true);
        stations[i].GetComponent<StationBase>().Enter();
    }
}