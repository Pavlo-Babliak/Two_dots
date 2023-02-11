using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunner : MonoBehaviour
{
    private void Awake()
    {
        IronSource.Agent.init("16aef9ed5", IronSourceAdUnits.BANNER);
    }
    void Start()
    {
        LoadBanner();
    }
    private void LoadBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.BOTTOM);
    }
}
