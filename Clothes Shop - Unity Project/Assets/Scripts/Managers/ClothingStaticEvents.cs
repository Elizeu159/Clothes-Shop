using System;

public static class ClothingStaticEvents
{
    public static Action<ClothingPieceSettings> OnRequestedClothingEquip;
    public static Action<ClothingPieceSettings> OnRequestedClothingTry;
    public static Action<ClothingPieceSettings> OnRequestedClothingBuy;
    public static Action<ClothingPieceSettings> OnRequestedClothingSell;

    public static Action<bool> OnShopStateChanged;

    public static Action<bool> OnNearShopStateChanged;
}
