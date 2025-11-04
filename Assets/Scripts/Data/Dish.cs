using UnityEngine;

[CreateAssetMenu(menuName = "FrickDish/Dish")]
public class Dish : ScriptableObject
{
    public string dishName;
    public Sprite icon;           // for UI order
    public float cookTime = 3f;
    public int scoreValue = 30;
    public bool isSpecial;  
    public GameObject rawPrefab;       // what spawns in Prep station
public GameObject cookedPrefab;    // what spawns in Serve station      // critic dish = x2 points
}
