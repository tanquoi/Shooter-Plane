using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [Header("Cài đặt thiết lập chung")]
    [Tooltip("Khoảng cách tàu di chuyển lên xuống dựa trên cài đặt người chơi")] 
    [SerializeField] float controlSpeed;

    [Tooltip("Khoảng cách người chơi di chuyển theo chiều ngang (horizontally)")] 
    [SerializeField] float xRange;
    [Tooltip("Khoảng cách người chơi di chuyển theo chiều dọc (vertically)")] 
    [SerializeField] float yRange;

    [Header("Số lượng súng")]
    [Tooltip("Nhập số lượng súng người chơi muốn")]
    [SerializeField] GameObject[] laser;

    [Header("điều chỉnh dựa trên vị trí màn hình")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("điều chỉnh dựa trên đầu vào của trình phát")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;


    float yThrow;
    float xThrow;
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    public void ProcessFiring()
    {
        
        if (Input.GetButton("Fire1"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }    
    }
    
    public void SetActiveLasers(bool isActive)
    {
        foreach (GameObject laser in laser)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }


    public void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

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
