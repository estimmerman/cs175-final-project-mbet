using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingScoreTrigger : MonoBehaviour {

    public Text scoreText;
    public Text strikeText;
    public GameObject SlideDoor;
    private int Fallen;

    private void OnTriggerEnter(Collider other)
    {
        if (Fallen != 1)
        {
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            Fallen = 1;
        }
        if (int.Parse(scoreText.text).ToString() == "10" && (strikeText.text != "STRIKE!"))
        {
            strikeText.text = "STRIKE!";
            scoreText.fontSize = 1;
            if (SlideDoor.transform.position.z > -100)
            {
                SlideDoor.GetComponent<Animation>().Play("SlideWall");
            }
        }
    }
}
