using UnityEngine;

public class EmergencyController : MonoBehaviour
{
    [Header("Emergency Lights")]
    [SerializeField] private Light[] room7Lights;
    [SerializeField] private AudioSource alarm;
    [SerializeField] private Color emergencyColor = Color.red;
    [SerializeField] private Color normalColor = new Color32(255, 243, 223, 255);
    [SerializeField] private float emergencyIntensity = 15.0f;
    [SerializeField] private float normalIntensity = 20.0f;
    private bool emergencyActive = false;

    public void OnClicked()
    {
        Debug.Log("EmergencyController: Emergency button clicked!");
        emergencyActive = !emergencyActive;
        SwitchLights();
        handleAlarm();
    }

    void SwitchLights()
    {
        foreach (var light in room7Lights)
        {
            if (light == null) continue;
            if (emergencyActive)
            {
                light.color = emergencyColor;
                light.intensity = emergencyIntensity;
            } else
            {
                light.color = normalColor;
                light.intensity = normalIntensity;
            }
        }
    }

    void handleAlarm()
    {
        if (emergencyActive) alarm.Play();
        else alarm.Stop();
    }
}
