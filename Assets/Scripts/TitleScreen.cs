using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadScene("Demo Scene");
    }

    public void CreditsButtonClicked()
    {
        SceneManager.LoadScene("Credits");
    }

    //Maybe attach that to an individual credits screen transition script...
    public void TitleButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }
}
