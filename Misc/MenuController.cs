using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public Text Title;
    public Button PlayButton;
    public Button InfoButton;
    public Button QuitButton;
    public Button BackToMenuButton;
    public Text ControlsText1;
    public Text AttackText1;
    public Button NextControls1;
    public Text WaypointText2;
    public Image WaypointImage2;
    public Text AmmoHealthText2;
    public Image AmmoImage2;
    public Image HealthImage2;
    public Text KillsText2;
    public Button NextControls2;
    public Button PreviousControls2;
    public Button PreviousControls3;
    public Text CreditsText3;
    public Text WarningText3;


    // Launches the game 
    public void Play() {
        SceneManager.LoadScene("Level 01");
    }

    // Loads the Info page
    public void Info() {
        hideAll();
        BackToMenuButton.gameObject.SetActive(true);
        ControlsText1.gameObject.SetActive(true);
        AttackText1.gameObject.SetActive(true);
        NextControls1.gameObject.SetActive(true);
    }

    // Quits the game
    public void Quit() {
        Application.Quit();
    }

    // Goes back to the main menu
    public void BackToMenu() {
        hideAll();
        Title.gameObject.SetActive(true);
        PlayButton.gameObject.SetActive(true);
        InfoButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
    }

    // Goes to the second Controls page
    public void NextPage1() {
        hideAll();
        BackToMenuButton.gameObject.SetActive(true);
        WaypointText2.gameObject.SetActive(true);
        WaypointImage2.gameObject.SetActive(true);
        AmmoHealthText2.gameObject.SetActive(true);
        AmmoImage2.gameObject.SetActive(true);
        HealthImage2.gameObject.SetActive(true);
        KillsText2.gameObject.SetActive(true);
        NextControls2.gameObject.SetActive(true);
        PreviousControls2.gameObject.SetActive(true);
    }

    // Goes to the third Controls page
    public void NextPage2() {
        hideAll();
        BackToMenuButton.gameObject.SetActive(true);
        PreviousControls3.gameObject.SetActive(true);
        CreditsText3.gameObject.SetActive(true);
        WarningText3.gameObject.SetActive(true);
    }

    // Goes back to the first Controls page
    public void PreviousPage2() {
        hideAll();
        BackToMenuButton.gameObject.SetActive(true);
        ControlsText1.gameObject.SetActive(true);
        AttackText1.gameObject.SetActive(true);
        NextControls1.gameObject.SetActive(true);
    }

    // Goes back to the second Controls page
    public void PreviousPage3() {
        hideAll();
        BackToMenuButton.gameObject.SetActive(true);
        WaypointText2.gameObject.SetActive(true);
        WaypointImage2.gameObject.SetActive(true);
        AmmoHealthText2.gameObject.SetActive(true);
        AmmoImage2.gameObject.SetActive(true);
        HealthImage2.gameObject.SetActive(true);
        KillsText2.gameObject.SetActive(true);
        NextControls2.gameObject.SetActive(true);
        PreviousControls2.gameObject.SetActive(true);
    }

    // Hides everything from the screen so the next text can be displayed
    void hideAll() {
        Title.gameObject.SetActive(false);
        PlayButton.gameObject.SetActive(false);
        InfoButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        BackToMenuButton.gameObject.SetActive(false);
        ControlsText1.gameObject.SetActive(false);
        AttackText1.gameObject.SetActive(false);
        NextControls1.gameObject.SetActive(false);
        WaypointText2.gameObject.SetActive(false);
        WaypointImage2.gameObject.SetActive(false);
        AmmoHealthText2.gameObject.SetActive(false);
        AmmoImage2.gameObject.SetActive(false);
        HealthImage2.gameObject.SetActive(false);
        KillsText2.gameObject.SetActive(false);
        NextControls2.gameObject.SetActive(false);
        PreviousControls2.gameObject.SetActive(false);
        PreviousControls3.gameObject.SetActive(false);
        CreditsText3.gameObject.SetActive(false);
        WarningText3.gameObject.SetActive(false);
    }


}
