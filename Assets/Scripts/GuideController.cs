using UnityEngine;
using UnityEngine.UI;

public class GuideController : MonoBehaviour
{
    public GameObject guideScrollView;
    private bool isGuideVisible = false;

    public void ToggleGuide()
    {
        isGuideVisible = !isGuideVisible;
        guideScrollView.SetActive(isGuideVisible);
    }
}