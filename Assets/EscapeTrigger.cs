using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Unity.FPS.Game
{
    public class EscapeTrigger : MonoBehaviour
    {
        public int totalCarParts = 1;
        private int collectedCarParts = 0;

        public TextMeshProUGUI warningText;
        public float warningDuration = 2f;
        private float warningTimer;
        public GameFlowManager gfm;

        void Start()
        {

            if (warningText != null)
            {
                warningText.gameObject.SetActive(false);
            }
        }

        void Update()
        {
            if (warningText.gameObject.activeSelf && Time.time > warningTimer)
            {
                warningText.gameObject.SetActive(false);
            }
        }

        public void CollectCarPart()
        {
            collectedCarParts++;
            if (collectedCarParts == totalCarParts)
            {
                ShowCollected("All Parts Collected, You can Escape!");
            }
            else
                ShowCollected("Part Collected");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 6)
            {
                if (collectedCarParts >= totalCarParts)
                {
                    //ShowWarning("Press F to escape!");
                    //if (Input.GetKeyDown(KeyCode.F))
                    //{
                    //    ShowWarning(" F!");
                        gfm.EndGame(true);
                    
                }
                else
                {
                    ShowWarning("You need more car parts to escape!");
                }
            }
        }

        // Display a warning message on the screen
        private void ShowWarning(string message)
        {
            if (warningText != null)
            {
                warningText.text = message;
                warningText.gameObject.SetActive(true);
                warningTimer = Time.time + warningDuration;
            }
        }
        private void ShowCollected(string message)
        {
            if (warningText != null)
            {
                warningText.text = message;
                warningText.gameObject.SetActive(true);
                warningTimer = Time.time + warningDuration;
            }
        }
    }
}
