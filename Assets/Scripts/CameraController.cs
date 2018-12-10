using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float cameraSpeed;
    public GameObject player;

    // Can't move camera until trigger
    public static bool canMoveCamera = false;

    private Vector3 offset;
    private Rigidbody rb;

    // Lerping editor-changeable variables
    public float lerpSpeed;
    public float zoomScale;

    // Lerping between z positions (zoom in/out)
    private bool isLerping = false;

    private Vector3 startPos;
    private Vector3 endPos;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        if (canMoveCamera)
        {
            // Just started lerping
            if (!isLerping && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O)))
            {
                isLerping = true;
                startTime = Time.time;
                startPos = transform.position;

                if (Input.GetKeyDown(KeyCode.I)) // I for in
                {
                    Vector3 zoomIn = new Vector3(0.0f, 0.0f, zoomScale);
                    endPos = transform.position += zoomIn;
                }
                else if (Input.GetKeyDown(KeyCode.O)) // O for out
                {
                    Vector3 zoomOut = new Vector3(0.0f, 0.0f, -1 * zoomScale);
                    endPos = transform.position += zoomOut;
                }

                journeyLength = Vector3.Distance(startPos, endPos);
            }

            if (isLerping)
            {
                float distCovered = (Time.time - startTime) * lerpSpeed;
                float fracJourney = distCovered / journeyLength;

                transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
                isLerping &= fracJourney < 1.0f;
            }
        }
    }

    void LateUpdate()
    {
        if (!canMoveCamera)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

            transform.position += movement * cameraSpeed;
        }
    }
}
