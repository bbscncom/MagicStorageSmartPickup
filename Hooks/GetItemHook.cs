using MagicStorage;
using MagicStorage.Components;
using MagicStorageSmartPickup.Items;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicStorageSmartPickup.Hooks {
    internal class GetItemHook {
        private static readonly log4net.ILog Logger = MagicStorageSmartPickup.Instance.Logger;
 
        public static Item Hook(Terraria.On_Player.orig_GetItem orig, Player player, int plr, Item returnItem, GetItemSettings settings)
        {
            var i = player.inventory.FirstOrDefault(i => i.type == ModContent.ItemType<MSSmartPickup>(), null);

            if (i == null) goto original;

            var bag = (MSSmartPickup)i.ModItem;

            if (bag.Location.X < 0 || bag.Location.Y < 0) goto original;

            Tile tile = Main.tile[bag.Location.X, bag.Location.Y];

            if (!tile.HasTile || tile.TileType != ModContent.TileType<StorageHeart>() || tile.TileFrameX != 0 || tile.TileFrameY != 0) goto original;
            if (!TileEntity.ByPosition.TryGetValue(bag.Location, out TileEntity te)) goto original;
            if (te.type != ModContent.TileEntityType<TEStorageHeart>()) goto original;

            TEStorageHeart heart = (TEStorageHeart)te;

            foreach (TEAbstractStorageUnit storageUnit in heart.GetStorageUnits())
            {
                if (storageUnit.HasSpaceInStackFor(returnItem))
                {
                    heart.TryDeposit(returnItem);
                    heart.ResetCompactStage();
                    StorageGUI.SetRefresh();
                    break;
                }
            }



            original:
            return orig(player, plr, returnItem, settings);

        }
    }
}
