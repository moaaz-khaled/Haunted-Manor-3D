using UnityEngine;
using System.Collections;

public class StaticGhost : MonoBehaviour
{
    public AudioSource GhostSound;
    private Player player;

    private ShowGhost showGhost;


    void Start()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        showGhost = FindFirstObjectByType<ShowGhost>();
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