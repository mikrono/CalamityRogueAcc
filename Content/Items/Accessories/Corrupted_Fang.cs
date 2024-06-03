using CalamityMod.Items.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalamityMod.Items;
using CalamityMod;
using CalamityRogueAcc.Common.ModPlayers;
using Terraria.Localization;

namespace CalamityRogueAcc.Content.Items.Accessories
{
    public class Corrupted_Fang : ModItem
    {
        public static int StealthDamageBonus = 10;
        public static int CursedInfernoDebuffTime = 150;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(StealthDamageBonus);

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = CalamityGlobalItem.RarityGreenBuyPrice;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AccessoryPlayer>().Corrupted_Fang = true;
            player.Calamity().rottenDogTooth = true;
            player.Calamity().bonusStealthDamage += StealthDamageBonus / 100f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<RottenDogtooth>()
                .AddIngredient(ItemID.ShadowScale, 3)
                //.AddRecipeGroup("Boss2Material", 3)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
