
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;// list of asteroid transforms
    public Transform enemyTransform;// enemy position
    public GameObject bombPrefab;// bomb prefab reference
    public Transform bombsTransform;// parent transform for bombs

    public Transform playerPost;// player position


    Vector2 spawnOffset = Vector2.down;



    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)// normalizes a vector and prints it to the console (done in class)
        {
            Debug.Log("Normalized Vector: " + Normalizer(new Vector2(-3, 2)));
        }

        if (Keyboard.current.bKey.wasPressedThisFrame)// spawns a bomb relative to the player position when b is pressed
        {
            SpawnBombAtOffset(transform.up);
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)// spawns a trail of bombs below the player position when t is pressed
        {
            SpawnBombTrail(0.8f, 5);// calls the trail spawn fuction with a spacing of 0.5 and 5 bombs totalS
        }
    }

    public void SpawnBombAtOffset(Vector3 inOffset)// spawns a bomb at the player position with an offset
    {
        Instantiate(bombPrefab, playerPost.position + (Vector3)inOffset, Quaternion.identity);// instantiates a bomb relative to the player position with an offset
    }

    public  void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs) // spawns a trail of bombs with a specified spacing and number of bombs
    {
        for (int i = 1; i <= inNumberOfBombs; i++) // for loop for spawning bombs 
        {
            Instantiate(bombPrefab, playerPost.position + new Vector3(0, inBombSpacing * -i, 0), Quaternion.identity); // spawns the bombs with the correct spacing
        }

    }

    public static Vector2 Normalizer(Vector2 normalized)// normalizes a vector and prints it to the console (done in class)
    {
        return normalized.normalized;// returns the noramlized vector
    }

    //public void Teleport(Vector2 jump)
    //{
    //    Vector2 direction = enemyTransform.position - playerPost.position;

    //    //playerPost.position = playerPost.position + (Vector3)jump;
    //}
      
}
