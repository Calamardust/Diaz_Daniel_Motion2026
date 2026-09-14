using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Transform playerPost;


    public Vector2 spawnOffset;



    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Normalized Vector: " + Normalizer(new Vector2(-3, 2)));
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
           
            
            SpawnBombAtOffset(Vector3.up);
        }
    }

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab, playerPost.position + (Vector3)inOffset, Quaternion.identity);
    }

    public static Vector2 Normalizer(Vector2 normalized)
    {
        return normalized.normalized;
    }

    public void Teleport(Vector2 jump)
    {
        Vector2 direction = enemyTransform.position - playerPost.position;

        //playerPost.position = playerPost.position + (Vector3)jump;
    }
      
}
