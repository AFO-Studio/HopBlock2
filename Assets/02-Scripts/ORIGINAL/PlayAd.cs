using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PlayAd : MonoBehaviour {

    void Start()
    {
#if UNITY_ADS
        Advertisement.Initialize("1700367", true);
#endif

    }

    IEnumerator ShowAdWhenReady()
    {
#if UNITY_ADS
        while (!Advertisement.IsReady())
            yield return null;
        Advertisement.Show();
#else
        yield return null;
#endif
    }

    public void PlayAdver()
    {
#if UNITY_ADS
        Advertisement.Show();
#endif
    }
}
