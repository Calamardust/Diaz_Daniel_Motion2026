using UnityEngine;

public class BoomPrefab : MonoBehaviour
{
    public GameObject flak;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            Instantiate(flak, transform.position, transform.rotation);
            Instantiate(flak, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
            Instantiate(flak, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
        }
    }
}