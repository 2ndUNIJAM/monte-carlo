using System.Collections;
using UnityEngine;

namespace MonteCarlo.Core
{
    public class SoundManager : SingletonBehaviour<SoundManager>
    {
        private AudioSource audioSource;

        private AudioClip revolverRifleClip;
        private AudioClip revolverCockClip;
        private AudioClip revolverShotClip;

        private AudioClip card001Clip;
        private AudioClip card002Clip;

        private AudioClip damageClip;

        private AudioClip coinFlipClip;
        private AudioClip coinDropClip;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            var revolverPath = "Sound/Revolver/";
            revolverRifleClip = Resources.Load<AudioClip>(revolverPath + "mix-rifle-spin");
            revolverCockClip = Resources.Load<AudioClip>(revolverPath + "cocking-a-revolver-6279");
            revolverShotClip = Resources.Load<AudioClip>(revolverPath + "single-pistol-gunshot-33-37187");

            var cardPath = "Sound/Card/";
            card001Clip = Resources.Load<AudioClip>(cardPath + "cardPlace3");
            card002Clip = Resources.Load<AudioClip>(cardPath + "cardPlace4");

            var damagePath = "Sound/Damage/";
            damageClip = Resources.Load<AudioClip>(damagePath + "hit20.mp3");

            var coinPath = "Sound/Coin/";
            coinFlipClip = Resources.Load<AudioClip>(coinPath + "coin-flip-shimmer-85750");
            coinDropClip = Resources.Load<AudioClip>(coinPath + "single-coin-170397");
        }

        public void onRevolverRifleClip()
        {
            Debug.Log("sound-rifle-spin");
            OnAudio(revolverRifleClip);
        }
        public void onRevolverCockClip()
        {
            Debug.Log("sound-cocking");
            OnAudio(revolverCockClip);
        }
        public void onRevolverShotClip()
        {
            Debug.Log("sound-shot");
            StartCoroutine(OnAudioCoroutine(new AudioClip[] { revolverShotClip, revolverRifleClip }, 1.7f));
        }

        public void onCardClip()
        {
            Debug.Log("sound-card");
            var clip = Random.Range(0f, 1f) < 0.5f ? card001Clip : card002Clip;
            OnAudio(clip);
        }
        public void onDamageClip()
        {
            Debug.Log("sound-damage");
            OnAudio(damageClip);
        }

        public void onCoinClip()
        {
            Debug.Log("sound-coin");
            StartCoroutine(OnAudioCoroutine(new AudioClip[] { coinFlipClip, coinDropClip }, 1.4f));
        }

        private void OnAudio(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }

        private IEnumerator OnAudioCoroutine(AudioClip[] audioClip, float delaytime)
        {
            foreach (var audio in audioClip)
            {
                audioSource.PlayOneShot(audio);
                yield return new WaitForSeconds(delaytime);
            }
        }

    }
}
