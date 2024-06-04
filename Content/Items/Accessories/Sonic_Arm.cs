using CalamityMod;
using CalamityMod.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityRogueAcc.Content.Items.Accessories
{
    public class Sonic_Arm : ModItem
    {
        static readonly int RogueAttackSpeedBonus = 20;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(RogueAttackSpeedBonus);

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 30;
            Item.accessory = true;
            Item.rare = ItemRarityID.Lime;
            Item.value = CalamityGlobalItem.RarityLimeBuyPrice;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Calamity().gloveOfRecklessness = true;
            player.GetAttackSpeed<RogueDamageClass>() += RogueAttackSpeedBonus / 100f;
        }
    }
}
