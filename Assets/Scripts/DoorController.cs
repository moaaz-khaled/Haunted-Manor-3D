using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{    
    public AudioSource DoorSound;

    private GameController gameController;
    private Animator doorAnimator;
    private Player player;
    public float DistanceReq = 2.5f;
    public bool isOpen , ReadyToOpen , ReadyToClose;
    private bool ShowUI;

    void Start() 
    {
        doorAnimator = GetComponent<Animator>();
        player = FindFirstObjectByType<Player>();
        gameController = FindFirstObjectByType<GameController>();
        ShowUI = false;
        isOpen = false;
        ReadyToOpen = true;
        ReadyToClose = false;
    }

    void Update()
    {        
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < DistanceReq) 
        {
            ShowUI = true;
            gameController.Text.text = isOpen ? "Press E to Close the door" : "Press E to Open the door";
            if(ReadyToOpen || ReadyToClose)
            {
                gameController.Text.gameObject.SetActive(ShowUI);
                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    gameController.Text.gameObject.SetActive(false);
                    if(!isOpen)
                        OpenDoor();
                    else if(isOpen)
                        CloseDoor();
                    DoorSound.Play();

                    if(CompareTag("NormalDoor"))
                        gameController.NormalDoor = gameObject;
                    if(CompareTag("leftDoor")) {
                        gameController.NormalDoor = null;
                        gameController.LastDoorLeft = gameObject;      
                    }              
                    if(CompareTag("RightDoor")) {
                        gameController.NormalDoor = null;
                        gameController.LastDoorRight = gameObject;
                    }
                }
            }
        }
        
        else {
            if(ShowUI) {
                ShowUI = false;
                gameController.Text.gameObject.SetActive(ShowUI);
            }
        }
    }

    public void OpenDoor() {
        isOpen = true;
        doorAnimator.SetBool("Open" , isOpen);
    }

    public void CloseDoor() {
        isOpen = false;
        doorAnimator.SetBool("Open" , isOpen);
    }

    // In Animation Events
    void SetReadyToOpenTrue(){
        ReadyToOpen = true;
    }

    void SetReadyToOpenFalse(){
        ReadyToOpen = false;
    }

    void SetReadyToCloseTrue(){
        ReadyToClose = true;
    }

    void SetReadyToCloseFalse(){
        ReadyToClose = false;
    }
    //
}