using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsLabel;
    float lastUpdateTime = 0;

    public void Update()
    {
        if (lastUpdateTime + .5f <= Time.time)
		{
            int current = (int)(1f / Time.unscaledDeltaTime);
            fpsLabel.text = $"{current} FPS";
            lastUpdateTime = Time.time;
		}
    }
}