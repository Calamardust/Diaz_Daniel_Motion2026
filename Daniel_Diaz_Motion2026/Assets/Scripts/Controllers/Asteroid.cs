using UnityEngine;

public class Asteroid : MonoBehaviour
{
   public float moveSpeed;
   public float arrivalDistance;
   public float maxFloatDistance;

   Vector3 finalPoint; 

   Vector3 randomPoint;


    // Start is called before the first frame update
    void Start()
    {
        NewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
   

    public void NewTarget() // calculates the new random position the asteroid has to reach 
    {
         randomPoint = new Vector3
            (Random.Range(maxFloatDistance, -maxFloatDistance), 
            Random.Range(maxFloatDistance, -maxFloatDistance), 
            Random.Range(maxFloatDistance, -maxFloatDistance));

        finalPoint = transform.position + randomPoint;
    }
    public void AsteroidMovement() // moves the asteroid towards the next point 
    {
        transform.position = Vector3.MoveTowards(transform.position, finalPoint, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, finalPoint) < arrivalDistance)
        {
            NewTarget(); // next target point
        }
        
    }

}
