using UnityEngine;

public class GameTime : MonoBehaviour
{
    public float time;
    
    private void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
    }
}
