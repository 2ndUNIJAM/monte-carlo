using UnityEngine;

public class BgmManager : MonoBehaviour
{
    [Header("This is background music settings")]
    [SerializeField] private AudioClip bgm;  // stage bgm
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = bgm; // set bgm
        OnStartBgm();
    }

    public void OnStartBgm()
    {
        audioSource.Play();
    }
}
