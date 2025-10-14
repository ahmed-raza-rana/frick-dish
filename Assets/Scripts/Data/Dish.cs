using UnityEngine;

[CreateAssetMenu(menuName = "FrickDish/Dish")]
public class Dish : ScriptableObject
{
    public string dishName;
    public Sprite icon;           // for UI order
    public float cookTime = 3f;
    public int scoreValue = 30;
    public bool isSpecial;        // critic dish = x2 points
}
