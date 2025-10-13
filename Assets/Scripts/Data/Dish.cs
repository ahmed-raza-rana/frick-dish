using UnityEngine;

[CreateAssetMenu(menuName = "Dish")]
public class Dish : ScriptableObject
{
    public string dishName;
    public Sprite icon;
    public int points;
    public float cookTime;
}
