using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed;
    [SerializeField] float xRange;
    [SerializeField] float yRange;

    [SerializeField] float positionPitchFactor = 2f;
    float yThrow;
    float xThrow;
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        
    }

    public void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow;
        float yaw = 0f;
        float roll = 0f;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    public void ProcessTranslation() //Quá trình chuyển động
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");


        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
