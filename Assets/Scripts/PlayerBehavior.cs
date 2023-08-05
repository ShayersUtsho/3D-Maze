using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 moveInput = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = (Input.GetKey(KeyCode.Keypad9) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad1) ? 1f : 0f);
        moveInput.z = (Input.GetKey(KeyCode.Keypad7) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad3) ? 1f : 0f);
        moveInput.y = (Input.GetKey(KeyCode.Keypad2) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad8) ? 1f : 0f);
    }
}
