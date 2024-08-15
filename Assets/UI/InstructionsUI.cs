using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    [SerializeField] GameObject instructionsUI;


    public void CloseIntructionsUI()
    {
        instructionsUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenInstructionsUI()
    {
        instructionsUI.SetActive(true);
        Time.timeScale = 0;

    }
}
