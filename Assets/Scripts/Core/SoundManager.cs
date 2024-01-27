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

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            var revolverPath = "Sound/Revolver/";
            revolverRifleClip = Resources.Load<AudioClip>(revolverPath + "mix-rifle-spin");
            revolverCockClip = Resources.Load<AudioClip>(revolverPath + "cocking-a-revolver-6279");
            revolverShotClip = Resources.Load<AudioClip>(revolverPath + "mix-shot-rifle-spin");

            var cardPath = "Sound/Card/";
            card001Clip = Resources.Load<AudioClip>(cardPath + "cardPlace3");
            card002Clip = Resources.Load<AudioClip>(cardPath + "cardPlace4");
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
            OnAudio(revolverShotClip);
        }
        public void onCardClip()
        {
            Debug.Log("sound-card");
            var clip = Random.Range(0f, 1f) < 0.5f ? card001Clip : card002Clip;
            OnAudio(clip);
        }

        private void OnAudio(AudioClip audioClip)
        {
            //if (SoundStaticData._dataInstance.isSound)
            //{
            audioSource.clip = audioClip;
            //audioSource.volume = SoundStaticData._dataInstance.soundVolume;
            audioSource.Play();
            //}
        }
    }
}
