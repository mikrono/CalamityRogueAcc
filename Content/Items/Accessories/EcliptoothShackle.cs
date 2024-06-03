using CalamityMod.Items;
using CalamityMod.Items.Materials;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace CalamityRogueAcc.Content.Items.Accessories
{
    public class EcliptoothShackle : ModItem
    {
        public static int DefaultDefenseStat = 10;
        public static int ArmorPenBonus = 15;
        public static int AttackSpeedBonus = 15;
        public static int EclipseDamageBonus = 10;
        public static int EclipseDefenseBonus = 10;
        public static int DayTimeDamageBonus = 5;
        public static int NightTimeDefenseBonus = 10;

        //TODO: Formatted Tooltip.

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ModContent.RarityType<DarkBlue>();
            Item.value = CalamityGlobalItem.RarityDarkBlueBuyPrice;
            Item.defense = DefaultDefenseStat;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetArmorPenetration<GenericDamageClass>() += ArmorPenBonus;
            player.GetAttackSpeed<GenericDamageClass>() += AttackSpeedBonus / 100f;
            if (Main.eclipse)
            {
                player.GetDamage<GenericDamageClass>() += EclipseDamageBonus / 100f;
                player.statDefense += EclipseDefenseBonus;
            }
            if (Main.dayTime)
            {
                player.GetDamage<GenericDamageClass>() += DayTimeDamageBonus / 100f;
            }
            else
            {
                player.statDefense += NightTimeDefenseBonus;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<DarksunFragment>()
                .AddIngredient<SharktoothShackle>()
                .AddIngredient<UelibloomBar>(7)
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }
}
