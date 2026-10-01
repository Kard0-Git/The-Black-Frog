using UnityEngine;

public abstract class UpgradeTemplate : ScriptableObject
{
  public abstract void applyPowerup(GameObject target);
}
