using CalamityMod;
using CalamityMod.Items;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
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
    public class VampireboneGlove : ModItem
    {
        public static readonly int rogueDamageBonus = 15;

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;
            Item.value = CalamityGlobalItem.RarityRedBuyPrice;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Calamity().vampiricTalisman = true;
            player.GetDamage<ThrowingDamageClass>() += rogueDamageBonus / 100f;
            player.GetModPlayer<AccessoryPlayer>().vampireboneGlove = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BloodstainedGlove>()
                .AddIngredient<VampiricTalisman>()
                .AddIngredient<MeldConstruct>(6)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
