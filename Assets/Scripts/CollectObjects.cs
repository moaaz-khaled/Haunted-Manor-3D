using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private GameController gameController;
    private VictoryPanel victoryPanel;

    [SerializeField] private GameObject Target;
    private Player player;

    private RandomPosition randomPosition;
    int RandIndex;

    private ScreenFader screenFader;

    public AudioSource CollectSound;

    private bool CanPickUp = false;
    private bool FirstFade = false;

    void Start() {
        gameController = FindFirstObjectByType<GameController>();
        player = FindFirstObjectByType<Player>();
        screenFader = FindFirstObjectByType<ScreenFader>();
        victoryPanel = FindFirstObjectByType<VictoryPanel>();

        randomPosition = FindFirstObjectByType<RandomPosition>();
        RandIndex = Random.Range(0, randomPosition.positions.Count);

        Target.transform.position = randomPosition.positions[RandIndex];
        Target.transform.rotation = Quaternion.Euler(randomPosition.Rotations[RandIndex]);
    }

    void Update() 
    {
        if(Target != null) 
        {
            
            float distance = Vector3.Distance(Target.transform.position, player.transform.position);
            if(distance < 2f && !FirstFade) 
            {
                FirstFade = true;
                screenFader.FadeToBlack();
                StartCoroutine(MoveTarget(1.5f));
                StartCoroutine(FadeBackAfterDelay(4f));
                SwitchDoorState();
            }

            if (CanPickUp && Input.GetKeyDown(KeyCode.C) && player.isIdle) {
                player.PickUpItemMode();
                gameController.Text.color = Color.white;
            }
        }
    }

    void CollectItem() // I Used This function in Animation Event <PickUP>
    {
        gameController.TargetScore.text = "x 1";
        if(Target != null)
            Destroy(Target);
        gameController.Text.gameObject.SetActive(false);
        CanPickUp = false;
        CollectSound.enabled = true;

        victoryPanel.ShowPannel();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Target")) {
            CanPickUp = true;
            gameController.Text.text = "Press C to pick up Target";
            gameController.Text.color = Color.black;
            if(player.isIdle)
                gameController.Text.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Target) {
            CanPickUp = false;
            gameController.Text.color = Color.white;
            gameController.Text.gameObject.SetActive(false);
        }
    }

    IEnumerator FadeBackAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        screenFader.FadeToClear();
    }

    IEnumerator MoveTarget(float delaySeconds) 
    {
        yield return new WaitForSeconds(delaySeconds);
        int NewPosition = Random.Range(0, randomPosition.positions.Count);
        while(NewPosition == RandIndex) {
            NewPosition = Random.Range(0, randomPosition.positions.Count);
        }
        Target.transform.position = randomPosition.positions[NewPosition];
        Target.transform.rotation = Quaternion.Euler(randomPosition.Rotations[NewPosition]);
    }

    void SwitchDoorState() 
    {
        if(gameController.NormalDoor != null) 
        {
            if(gameController.NormalDoor.GetComponent<DoorController>().isOpen == true)
                gameController.NormalDoor.GetComponent<DoorController>().CloseDoor();
            else
                gameController.NormalDoor.GetComponent<DoorController>().OpenDoor();
            gameController.NormalDoor.GetComponent<DoorController>().DoorSound.Play();
        }

        if(gameController.LastDoorLeft != null) 
        {
            if(gameController.LastDoorLeft.GetComponent<DoorController>().isOpen == true)
                gameController.LastDoorLeft.GetComponent<DoorController>().CloseDoor();
            else
                gameController.LastDoorLeft.GetComponent<DoorController>().OpenDoor();
            gameController.LastDoorLeft.GetComponent<DoorController>().DoorSound.Play();
        }

        if(gameController.LastDoorRight != null) 
        {
            if(gameController.LastDoorRight.GetComponent<DoorController>().isOpen == true)
                gameController.LastDoorRight.GetComponent<DoorController>().CloseDoor();
            else
                gameController.LastDoorRight.GetComponent<DoorController>().OpenDoor();
            gameController.LastDoorRight.GetComponent<DoorController>().DoorSound.Play();
        }
    }
}