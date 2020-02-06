using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Get Current mouse screen position
        Vector3 mousePos2D = Input.mousePosition;                 
        mousePos2D.z = -Camera.main.transform.position.z;                        
        
        //CameraZ pos sets how far to push mouse
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Convert 2d into 3d space
        Vector3 pos = this.transform.position;

        //Move X of Basket to Mouse X
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll)
    {  
        GameObject collidedWith = coll.gameObject;
        //What Hit Basket
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }

    }

}
