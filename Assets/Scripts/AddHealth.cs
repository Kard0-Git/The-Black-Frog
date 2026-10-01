using UnityEngine;

//Health Upgrade
public class AddHealth : UpgradeTemplate
{
    public float HealthGain;
    public override void applyPowerup(GameObject target)
    {
       target.GetComponent<HealthScript>().GainHealth();
    }
}
