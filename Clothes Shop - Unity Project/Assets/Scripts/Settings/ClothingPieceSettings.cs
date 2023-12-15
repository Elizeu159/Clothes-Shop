using UnityEngine;

public enum ClothingPieceTypes { Hood, Torso, Pelvis, Left_Shoulder, Right_Shoulder, Left_Wrist, Right_Wrist, Left_Boot, Right_Boot, Left_Leg, Right_Leg, Left_Elbow, Right_Elbow};

[CreateAssetMenu(fileName = "Clothing", menuName = "ScriptableObjects/ClothingScriptableObject")]
public class ClothingPieceSettings : ScriptableObject
{
    public string pieceName;
    public Sprite pieceSprite;

    public int buyPrice = 100;
    public int sellPrice = 50;

    public bool owned;
    public bool equipped;

    public ClothingPieceTypes pieceType;
}
