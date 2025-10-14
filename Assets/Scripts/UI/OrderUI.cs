using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderUI : MonoBehaviour
{
    public Dish dish;
    public Image icon;
    public TMP_Text nameText;
    public Image timerBar;
    public Image avatar;
    public float timeLimit = 20f;
    float timer;

    bool completed;

    public void Setup(Dish d)
    {
        dish = d;
        icon.sprite = d.icon;
        nameText.text = d.dishName;
        timer = timeLimit;
    }

    void Update()
    {
        if (completed) return;
        timer -= Time.deltaTime;
        timerBar.fillAmount = timer / timeLimit;
        if (timer <= 0)
        {
            FailOrder();
        }
    }

    public void Complete()
    {
        completed = true;
        avatar.color = Color.green; // happy
        Destroy(gameObject, 1.2f);
    }

    void FailOrder()
    {
        completed = true;
        avatar.color = Color.red; // sad
        Destroy(gameObject, 1.2f);
    }
}
