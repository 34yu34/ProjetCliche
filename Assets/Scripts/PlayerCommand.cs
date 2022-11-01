using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "Player/Command", order = 0)]
public abstract class PlayerCommand : ScriptableObject
{
    
    
    public abstract void Execute(Player player);
}