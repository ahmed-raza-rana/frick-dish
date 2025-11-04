using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StationNavigator : MonoBehaviour
{
    [Header("Stations")]
    public GameObject[] stations;
    
    public string[] stationNames;
    private int index = 0;

    [Header("UI References")]
    public Button nextButton;
    public Button prevButton;
    public Button actionButton;
    public TMP_Text actionButtonText;
    
    

    void Start()
    {
        Activate(0);
        UpdateNavButtons();
    }

    public void Next()
    {
        Switch(1);
    }

    public void Prev()
    {
        Switch(-1);
    }

    void Switch(int dir)
    {
        // Exit current station
        stations[index].GetComponent<StationBase>().Exit();
        stations[index].SetActive(false);

        // Move to next or previous
        index = Mathf.Clamp(index + dir, 0, stations.Length - 1);

        // Activate new station
        Activate(index);

        // Update navigation button visibility
        UpdateNavButtons();
    }

    void Activate(int i)
    {
        GameObject current = stations[i];
        current.SetActive(true);
        StationBase station = current.GetComponent<StationBase>();
        station.Enter();

        // animate text
        actionButtonText.DOFade(0f, 0.15f).OnComplete(() =>
        {
            actionButtonText.text = stationNames[i].ToUpper();
            actionButtonText.DOFade(1f, 0.15f);
        });

        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(() => station.Action());
    }

    void UpdateNavButtons()
    {
        // Hide prev if on first station
        prevButton.gameObject.SetActive(index > 0);

        // Hide next if on last station
        nextButton.gameObject.SetActive(index < stations.Length - 1);
    }
}
