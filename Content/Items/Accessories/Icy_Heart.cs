using CalamityMod.Items;
using CalamityRogueAcc.Common.ModPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityRogueAcc.Content.Items.Accessories
{
    public class Icy_Heart : ModItem
    {
        public static readonly int DebuffDurationInSec = 2;

        public static readonly float icySpearDamgeMultiplier = 1.5f;

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = CalamityGlobalItem.RarityPinkBuyPrice;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AccessoryPlayer>().icy_Heart = true;
        }
    }
}
