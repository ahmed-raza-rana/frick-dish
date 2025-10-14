using UnityEngine;

public class CameraMover : MonoBehaviour {
    public Transform[] points;
    int index;
    public float moveSpeed = 5f;

    void Update() {
        transform.position = Vector3.Lerp(
            transform.position, points[index].position, Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.Lerp(
            transform.rotation, points[index].rotation, Time.deltaTime * moveSpeed);
    }
    public void Next(){ index = Mathf.Clamp(index+1,0,points.Length-1); }
    public void Prev(){ index = Mathf.Clamp(index-1,0,points.Length-1); }
}

