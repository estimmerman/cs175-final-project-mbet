using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampDoorController : MonoBehaviour {

    public GameObject TrapDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwingingBall"))
        {
            TrapDoor.GetComponent<Animation>().Play("TrapAnim");
            gameObject.SetActive(false);

            CameraController.canMoveCamera = true;
        }
    }
}
