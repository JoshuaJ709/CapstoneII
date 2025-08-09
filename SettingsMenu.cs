using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    //Variables
    public Slider fovSlider; //For Changing FOV
    public Slider sensSlider;
    public Camera mainCamera; //FOV Change & Sensitivity

    public void returnBack()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
    public void Apply()
    {
        mainCamera.fieldOfView = fovSlider.value;
        MouseMovement.sensY = sensSlider.value;
        MouseMovement.sensX = sensSlider.value;
    }
}