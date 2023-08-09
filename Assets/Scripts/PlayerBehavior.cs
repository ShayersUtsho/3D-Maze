using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 moveInput = Vector3.zero;
    [SerializeField] private float speed = 5f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private bool win = false;
    // Start is called before the first frame update
    [SerializeField] private GameObject MazeLevel1;
    [SerializeField] private GameObject MazeLevel2;
    [SerializeField] private GameObject MazeLevel3;
    [SerializeField] private GameObject MazeLevel4;
    [SerializeField] private GameObject MazeLevel5;
    [SerializeField] private GameObject WinMessage;
    private Vector3 chamber = Vector3.one;
    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!win)
        {
            chamber = transform.position / 5;
            Debug.Log("Chamber no. " + chamber.y.ToString());
            Debug.Log("Initial Move Input - " + moveInput.ToString());
            moveInput.x = (Input.GetKey(KeyCode.Keypad9) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad1) ? 1f : 0f);
            moveInput.z = (Input.GetKey(KeyCode.Keypad7) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad3) ? 1f : 0f);
            moveInput.y = (Input.GetKey(KeyCode.Keypad2) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad8) ? 1f : 0f);
            Debug.Log("Final Move Input - " + moveInput.ToString());
            moveInput = moveInput.normalized;

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                switch ((int)chamber.y)
                {
                    case 0:
                        MazeLevel1.SetActive(true);
                        break;
                    case 1:
                        MazeLevel2.SetActive(true);
                        break;
                    case 2:
                        MazeLevel3.SetActive(true);
                        break;
                    case 3:
                        MazeLevel4.SetActive(true);
                        break;
                    case 4:
                        MazeLevel5.SetActive(true);
                        break;
                    default:
                        Debug.Log("Switch Case out of bounds");
                        break;
                }
            }
            if (Input.GetKeyUp(KeyCode.Keypad5))
            {
                switch ((int)chamber.y)
                {
                    case 0:
                        MazeLevel1.SetActive(false);
                        break;
                    case 1:
                        MazeLevel2.SetActive(false);
                        break;
                    case 2:
                        MazeLevel3.SetActive(false);
                        break;
                    case 3:
                        MazeLevel4.SetActive(false);
                        break;
                    case 4:
                        MazeLevel5.SetActive(false);
                        break;
                    default:
                        Debug.Log("Switch Case out of bounds");
                        break;
                }
            }
            moveInput = moveInput.normalized;

            Debug.Log("Initial CC Position - " + cc.transform.position.ToString());
            cc.Move(moveInput * speed * Time.deltaTime);
            if (new Vector3(moveInput.x, 0f, moveInput.z) != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(new Vector3(moveInput.x, 0f, moveInput.z));
            Debug.Log("Final CC Position - " + cc.transform.position.ToString());
        }
        else
        {
            WinMessage.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            win = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            win = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
