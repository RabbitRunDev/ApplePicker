using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 10f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 20f;

    // Chance that the AppleTree turns around
    public float chanceToChangeDirections = 0.02f;

    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    // Dropping Apples every second
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //	Changing	Direction

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            //Move Right
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            //Move Left
            speed = -Mathf.Abs(speed);
        }
        
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            //Change Direction
            speed *= -1;
        }
    }
}
