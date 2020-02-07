using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInstancer : MonoBehaviour
{

    public GameObject cube;
    public int rows;
    public int columns;
    public int spacing;

    private Vector3 instancePos = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        for (int r = 0; r < rows; r++)
        {
            instancePos.z = 0;
            instancePos.x += spacing;
            for (int c = 0; c < columns; c++)
            {
                Instantiate(cube);
                cube.transform.position = instancePos;
                instancePos.z += spacing;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
