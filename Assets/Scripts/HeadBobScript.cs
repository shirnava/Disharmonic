using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobScript : MonoBehaviour
{

    [SerializeField] private bool enable = true;
    [SerializeField, Range(0,0.1f)] private float strength = 0.002f;
    [SerializeField, Range(0,30)] private float freq = 17.0f;

    [SerializeField] private Transform camera = null;
    [SerializeField] private Transform cameraHolder = null;

    private float toggspeed=3.0f;
    private Vector3 startpos;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        startpos = camera.localPosition;
    }

    private Vector3 stepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.x += Mathf.Sin(Time.time * freq) * strength;
        pos.y += Mathf.Cos(Time.time * freq / 2) * strength * 2;
        return pos;
    }

    private void CheckPosition()
    {
        float speed = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;

        if (speed < toggspeed) return;
        if (!controller.isGrounded) return;

        PlayMotion(stepMotion());
    }

    private void ResetPosition()
    {
        if (camera.localPosition == startpos) return;
        camera.localPosition = Vector3.Lerp(camera.localPosition, startpos, 1 * Time.deltaTime);
    }

    private void PlayMotion(Vector3 motion)
    {
        camera.localPosition += motion;

    }
    
    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(cameraHolder.localPosition.x,cameraHolder.localPosition.y,cameraHolder.localPosition.z);
        pos += cameraHolder.forward * 15.0f;
        return pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enable) return;

        CheckPosition();
        ResetPosition();

        // camera.LookAt(FocusTar÷\get());
    }
}
