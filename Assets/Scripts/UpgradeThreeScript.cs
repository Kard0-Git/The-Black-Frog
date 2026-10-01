using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeThreeScript :  UpgradeHandler
{
   public override void OnAcceptPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        
    }
}
