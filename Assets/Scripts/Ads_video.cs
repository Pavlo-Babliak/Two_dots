using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ads_video : MonoBehaviour
{
    public TextMeshProUGUI number;
    public TextMeshProUGUI money;
    public GameObject syndyk;
    public GameObject Ads_box;
    private void Awake()
    {
        IronSource.Agent.init("16aef9ed5");
    }
    private void Start()
    {
        IronSource.Agent.shouldTrackNetworkState(true);
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
    }
    void RewardedVideoAvailabilityChangedEvent(bool available)
    {
        bool rewardedVideoAvailability = available;
    }
    public void RewardedVideoAdClosedEvent()
    {
        Ads_box.SetActive(true);
        int i = Random.Range(20, 100);
        number.text = "+" + i;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + i);
        money.text =System.Convert.ToString(PlayerPrefs.GetInt("Money"));
        IronSource.Agent.init("16aef9ed5");
        IronSource.Agent.shouldTrackNetworkState(true);
    }
    public void Ads()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            IronSource.Agent.showRewardedVideo();
            syndyk.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            syndyk.SetActive(true);
        }
    }
}
