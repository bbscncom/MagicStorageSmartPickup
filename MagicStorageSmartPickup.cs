using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using MagicStorageSmartPickup.Hooks;

using MagicStorageSmartPickup.ILPatches;

namespace MagicStorageSmartPickup
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class MagicStorageSmartPickup : Mod
	{
        public static MagicStorageSmartPickup Instance => ModContent.GetInstance<MagicStorageSmartPickup>();

        // IL Patches
        private PlayerUpdatePatch playerUpdatePatch = new();

        public override void Load()
        {
            /*Terraria.IL_Player.Update += playerUpdatePatch.Patch;*/

            Terraria.On_Player.GetItem += GetItemHook.Hook;
        }

        public override void Unload()
        {
            /*Terraria.IL_Player.Update -= playerUpdatePatch.Patch;*/

            Terraria.On_Player.GetItem -= GetItemHook.Hook;

            base.Unload();
        }
    }
}
