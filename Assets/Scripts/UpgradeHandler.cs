using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class UpgradeHandler : MonoBehaviour
{
   GameTextHandler game_ui;

//What to do when the button is pressed; 
  public virtual void OnAcceptPress()
    {
        game_ui = FindAnyObjectByType<GameTextHandler>();

        game_ui.disableUpgradeMenu();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }





}
