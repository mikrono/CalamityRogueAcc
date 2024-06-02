//using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using System.Linq;
using CalamityRogueAcc.Content.Items.Accessories;

namespace CalamityRogueAcc.Content.Items
{
    public class CalRogueAccGlobalItem : GlobalItem
    {
        [JITWhenModsEnabled("CalamityMod")]
		public override void ModifyItemLoot(Item item, ItemLoot loot)
		{
            switch (item.type)
            {
                case ItemID.WallOfFleshBossBag:
                    loot.Add(new CommonDrop(ModContent.ItemType<Flesh_Drive>(), 10));
                    break;
            }
        }
    }
}