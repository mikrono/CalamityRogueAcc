using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using CalamityMod.Items;
using CalamityMod;

namespace CalamityRogueAcc.Content.Items.Accessories
{
    public class Sonic_Arm : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 30;
            Item.accessory = true;
            Item.value = CalamityGlobalItem.RarityLimeBuyPrice;
            Item.rare = ItemRarityID.Lime;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed<RogueDamageClass>() += 0.2f;
        }
    }
}
