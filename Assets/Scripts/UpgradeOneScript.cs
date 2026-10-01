using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeOneScript : UpgradeHandler
{
    public override void OnAcceptPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
