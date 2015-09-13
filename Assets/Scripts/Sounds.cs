using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {
    [System.Serializable]
    public struct SlothSoundzz
    {
        public FMODAsset _music;
        public FMODAsset _explosion;
        public FMODAsset _jump;
        public FMODAsset _lazer;
        public FMODAsset[] _powerUp;
        public FMODAsset _start;
        public FMODAsset _deadSloth;
        public FMODAsset _speedBoost;
    }


    public SlothSoundzz _sounds;
    private static Sounds _instance = null;

    public static Sounds Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Sounds").GetComponent<Sounds>();
            }
               
            return _instance;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public static void OneShot(FMODAsset asset_)
    {
        FMOD_StudioSystem.instance.PlayOneShot(asset_, new Vector3(0,0,0));
    }
}
