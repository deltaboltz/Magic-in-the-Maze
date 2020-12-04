using UnityEngine;
using UnityEngine.UI;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    [DefaultExecutionOrder(2000)]
    public class LevelRotator : MonoBehaviour
    {
        public Text xRotText, yRotText, zRotText;

        public Slider xRotSlider, yRotSlider, zRotSlider;

        public KeyCode showHideMenuKey;

        private Vector3 originalGravity;

        private void Start()
        {
            originalGravity = Physics.gravity;
        }

        private void Update()
        {

        }

        public void HandleRotationChange()
        {
            Quaternion newRot = Quaternion.Euler(xRotSlider.value, yRotSlider.value, zRotSlider.value);
            transform.rotation = newRot;
            Physics.gravity = newRot * originalGravity;
        }

        private void SetEnableComponents(bool enabled)
        {
            Camera.main.GetComponent<OrbitingCamera>().enabled = enabled;

            FindObjectOfType<SimpleCharacterController>().enabled = enabled;

            foreach (var m in FindObjectsOfType<MovingPlatform>())
            {
                m.enabled = enabled;
            }
        }
    } 
}
