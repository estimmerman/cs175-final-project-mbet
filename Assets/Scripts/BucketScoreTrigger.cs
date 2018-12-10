using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketScoreTrigger : MonoBehaviour {

    public Text scoreText;
    public int scoreValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GenericMarble"))
        {
            scoreText.text = (int.Parse(scoreText.text) + scoreValue).ToString();
        }
    }
}
