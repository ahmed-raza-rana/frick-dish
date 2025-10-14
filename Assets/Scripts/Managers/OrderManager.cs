using UnityEngine;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    [Header("Order Settings")]
    public Dish[] dishLibrary;
    public GameObject orderUIPrefab;
    public Transform orderParent;
    public int maxOrders = 3;
    public float orderSpawnGap = 5f;

    private List<OrderUI> activeOrders = new();

    void Start()
    {
        InvokeRepeating(nameof(SpawnOrder), 1f, orderSpawnGap);
    }

    void SpawnOrder()
    {
        if (activeOrders.Count >= maxOrders) return;

        Dish d = dishLibrary[Random.Range(0, dishLibrary.Length)];
        GameObject obj = Instantiate(orderUIPrefab, orderParent);
        OrderUI ui = obj.GetComponent<OrderUI>();
        ui.Setup(d);
        activeOrders.Add(ui);
    }

    public void CompleteOrder(Dish dish)
    {
        // Match dish from queue
        for (int i = 0; i < activeOrders.Count; i++)
        {
            if (activeOrders[i].dish == dish)
            {
                activeOrders[i].Complete();
                activeOrders.RemoveAt(i);
                int points = dish.isSpecial ? dish.scoreValue * 2 : dish.scoreValue;
                GameManager.I.AddScore(points);
                break;
            }
        }
    }
}
