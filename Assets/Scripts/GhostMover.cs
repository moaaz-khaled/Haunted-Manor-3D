using UnityEngine;
using System.Collections;

public class GhostMover : MonoBehaviour
{
    private Vector3 initialPosition , moveDirection;
    [SerializeField] public float maxDistance = 12f , speed = 5f;
    public AudioSource GhostSound;
    private Player player;
    private bool Show;

    private ShowGhost showGhost;


    void Start()
    {
        initialPosition = transform.position;
        moveDirection = transform.forward.normalized;
        player = FindFirstObjectByType<Player>();
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        showGhost = FindFirstObjectByType<ShowGhost>();
        Show = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        float distanceMoved = Vector3.Distance(transform.position, initialPosition);
        float VerticalDistance = Mathf.Abs(player.transform.position.y - gameObject.transform.position.y);
        if(distance <= 9.5f && !Show && VerticalDistance < 0.3f)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            GhostSound.enabled = true;
            transform.position += moveDirection * speed * Time.deltaTime;
            if(distanceMoved >= maxDistance){
                Show = true;
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                GhostSound.enabled = false;
            }
        }

        else if(distance > 20f && VerticalDistance >= 0.3f) {
            Show = false;
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            GhostSound.enabled = false;
            gameObject.transform.position = initialPosition;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            showGhost.ShowGhostEffect();
            StartCoroutine(HandleGhostDisappearance());
        }
    }

    IEnumerator HandleGhostDisappearance()
    {
        yield return new WaitForSeconds(4f);
        showGhost.HideGhostEffect();
        Destroy(gameObject);
    }
}