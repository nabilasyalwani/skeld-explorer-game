using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Klik: " + hit.collider.name);

                hit.collider
                   .GetComponent<RedStartButton>()
                   ?.OnClicked();

                hit.collider
                   .GetComponent<EmergencyController>()
                   ?.OnClicked();

                hit.collider
                   .GetComponent<OpenMap2DController>()
                   ?.OnClicked();

                hit.collider
                   .GetComponent<SleepController>()
                   ?.OnClicked();

                hit.collider
                   .GetComponent<WatchController>()
                   ?.OnClicked();
            }
        }
    }
}
