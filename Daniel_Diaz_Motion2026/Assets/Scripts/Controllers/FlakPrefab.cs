using UnityEngine;

public class FlakPrefab : MonoBehaviour
{

    public float velocity;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * velocity;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
