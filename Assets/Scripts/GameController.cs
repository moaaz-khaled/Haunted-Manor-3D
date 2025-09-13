using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI TargetScore;
    public AudioSource GhostSound;

    public GameObject LastDoorLeft , LastDoorRight , NormalDoor;

    void Start() {
        Text.gameObject.SetActive(false);
        TargetScore.text = "x 0";
        TargetScore.gameObject.SetActive(true);
        GhostSound.enabled = true;

        LastDoorLeft = null;
        LastDoorRight = null;
        NormalDoor = null;
    }

    void Update() {

    }
}
