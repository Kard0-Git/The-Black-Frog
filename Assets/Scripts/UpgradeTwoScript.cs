using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeTwoScript : UpgradeHandler
{
     public override void OnAcceptPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }
}
