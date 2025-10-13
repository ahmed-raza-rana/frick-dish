using UnityEngine;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    public Dish[] dishes;
    public Transform orderParent;
    public GameObject orderUIPrefab;
    List<Dish> active = new();

    void Start() => SpawnOrder();

    void SpawnOrder()
    {
        Dish d = dishes[Random.Range(0, dishes.Length)];
        active.Add(d);
        Instantiate(orderUIPrefab, orderParent).GetComponent<OrderUI>().Setup(d);
    }

    public void Serve(Dish d)
    {
        if (active.Contains(d))
        {
            active.Remove(d);
            GameManager.I.AddScore(d.points);
        }
    }
}