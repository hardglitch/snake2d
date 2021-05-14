using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace ADS
{
    public class ADSettings : MonoBehaviour, IInterstitialAdListener, IBannerAdListener
    {
        private const string AppKey = "4225851449b57e78d57c6bed8417256a92351c910b80292e";
        private const int ADTypes = Appodeal.BANNER_BOTTOM | Appodeal.INTERSTITIAL;

        private void Start()
        {
            Appodeal.initialize(AppKey, ADTypes,true);
            
            Appodeal.setInterstitialCallbacks(this);
            Appodeal.setBannerCallbacks(this);
        }

        public void ShowInterstitial()
        {
            if (Appodeal.canShow(Appodeal.INTERSTITIAL) && !(Appodeal.isPrecache(Appodeal.INTERSTITIAL)))
                Appodeal.show(Appodeal.INTERSTITIAL);
        }

        public void ShowBanner()
        {
            Appodeal.show(Appodeal.BANNER_BOTTOM);
        }
        
        public void HideBanner()
        {
            Appodeal.hide(Appodeal.BANNER_BOTTOM);
        }

        #region Interfaces Realisations
        public void onInterstitialLoaded(bool isPrecache)
        {
            Debug.Log("onInterstitialLoaded");
        }

        public void onInterstitialFailedToLoad()
        {
            Debug.Log("onInterstitialFailedToLoad");
        }

        public void onInterstitialShowFailed()
        {
            Debug.Log("onInterstitialShowFailed");
        }

        public void onInterstitialShown()
        {
            Debug.Log("onInterstitialShown");
        }

        public void onInterstitialClosed()
        {
            Debug.Log("onInterstitialClosed");
        }

        public void onInterstitialClicked()
        {
            Debug.Log("onInterstitialClicked");
        }

        public void onInterstitialExpired()
        {
            Debug.Log("onInterstitialExpired");
        }

        public void onBannerLoaded(int height, bool isPrecache)
        {
            Debug.Log("onBannerLoaded");
        }

        public void onBannerFailedToLoad()
        {
            Debug.Log("onBannerFailedToLoad");
        }

        public void onBannerShown()
        {
            Debug.Log("onBannerShown");
        }

        public void onBannerClicked()
        {
            Debug.Log("onBannerClicked");
        }

        public void onBannerExpired()
        {
            Debug.Log("onBannerExpired");
        }
        #endregion
    }
}
