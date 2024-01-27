
public class SoundStaticData : SingletonBehaviour<SoundStaticData>
{
    public static SoundStaticData _dataInstance;

    // background music on/off
    public bool isBgm = true;

    // effect sound on/off
    public bool isSound = true;

    // background music volume;
    public float bgmVolume = 1f;

    // effect sound volume;
    public float soundVolume = 1f;

    //private void Awake()
    //{
    //    var obj = FindObjectsOfType<SoundStaticData>();

    //    if (obj.Length == 1)
    //    {
    //        _dataInstance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
