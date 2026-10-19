using UnityEngine;

public class Ray : MonoBehaviour
{
    public Transform targetTransform;
    public GameObject RadBug;
    public float rotationSpeed;

    float timer = 5f;

    void Update()
    {
        tracking();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            shootRadBug();
            timer = 5;
        }
    }

    void tracking ()
    {

        Vector3 directionToTarget = targetTransform.position - transform.position;


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

    void shootRadBug ()
    {
        
        {
            Instantiate(RadBug, transform.position, transform.rotation);
        }
    }
}
