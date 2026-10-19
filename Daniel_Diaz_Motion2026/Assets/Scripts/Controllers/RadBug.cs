using UnityEngine;

public class RadBug : MonoBehaviour
{
    public float velocity;

    public float timer;

    public GameObject player;

    public float rotationSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * velocity;
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 directionToTarget = player.transform.position - transform.position;


            //Should we turn left or right:
            bool shouldWeTurnRight = false;
            float dotProductOfRight = TestAngles.VectorDot(directionToTarget, transform.right);
            shouldWeTurnRight = dotProductOfRight > 0f;

            if (shouldWeTurnRight)
            {
                transform.eulerAngles -= Vector3.forward * rotationSpeed * Time.deltaTime;
            }
            else
            {
                transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            }
        }
    }
}
