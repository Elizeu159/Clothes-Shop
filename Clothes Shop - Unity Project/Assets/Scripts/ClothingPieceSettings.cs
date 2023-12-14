using UnityEngine;

public enum ClothingLocations { Hood, Torso, Pelvis, LeftShoulder, RightShoulder, LeftWrist, RightWrist, LeftBoot, RightBoot, LeftLeg, RightLeg };

[CreateAssetMenu(fileName = "Clothing", menuName = "ScriptableObjects/ClothingScriptableObject")]
public class ClothingPieceSettings : ScriptableObject
{
    public string pieceName;
    public Sprite pieceSprite;

    public int buyPrice = 100;
    public int sellPrice = 50;

    public ClothingLocations pieceLocation;

    
}
