using UnityEngine;

public class LaserPrefab : MonoBehaviour
{
    public GameObject boom;
    public float velocity;
    public float timer;
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * velocity;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            Instantiate(boom, transform.position, transform.rotation);
        }
    }
}
