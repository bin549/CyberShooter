using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
    private float randomTime;
    private bool routineStarted = false;

    public bool isHit = false;

    [Header("Customizable Options")] public float minTime, maxTime;

    [Header("Audio")] public AudioClip upSound, downSound;
    public AudioSource audioSource;

    private void Update() {
        randomTime = Random.Range(minTime, maxTime);
        if (isHit) {
            if (!routineStarted) {
                gameObject.GetComponent<Animation>().Play("target_down");
                audioSource.GetComponent<AudioSource>().clip = downSound;
                audioSource.Play();
                StartCoroutine(DelayTimer());
                routineStarted = true;
            }
        }
    }

    private IEnumerator DelayTimer() {
        yield return new WaitForSeconds(randomTime);
        gameObject.GetComponent<Animation>().Play("target_up");
        audioSource.GetComponent<AudioSource>().clip = upSound;
        audioSource.Play();
        isHit = false;
        routineStarted = false;
    }
}