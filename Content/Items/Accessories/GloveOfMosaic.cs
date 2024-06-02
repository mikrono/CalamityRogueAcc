using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Items;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamityRogueAcc.Common.ModPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityRogueAcc.Content.Items.Accessories
{
    public class GloveOfMosaic : ModItem
    {
        public static readonly int RogueStealthStrikeArmorPenBonus = 10;
        public static readonly int RogueStealthStrikeDamageBonus = 10;
        public static readonly int RogueVelocityBonus = 15;
        public static readonly int GenericDamageBonus = 10;
        public static readonly int GenericCritBonus = 15;
        public static readonly int RogueAttackSpeedBonus = 15;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(RogueStealthStrikeArmorPenBonus, RogueStealthStrikeDamageBonus, RogueVelocityBonus, GenericCritBonus, GenericDamageBonus, RogueAttackSpeedBonus);

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 50;
            Item.accessory = true;
            Item.rare = ModContent.RarityType<DarkBlue>();
            Item.value = CalamityGlobalItem.RarityDarkBlueBuyPrice;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AccessoryPlayer>().StealthStrikeArmorPen += RogueStealthStrikeArmorPenBonus;
            player.Calamity().bonusStealthDamage += RogueStealthStrikeDamageBonus / 100f;
            player.Calamity().rogueVelocity += RogueVelocityBonus / 100f;
            player.GetDamage<GenericDamageClass>() += GenericDamageBonus / 100f;
            player.GetCritChance<GenericDamageClass>() += GenericCritBonus;
            player.GetAttackSpeed<RogueDamageClass>() += RogueAttackSpeedBonus / 100f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<ElectriciansGlove>()
                .AddIngredient<GloveOfRecklessness>()
                .AddIngredient<GloveOfPrecision>()
                .AddIngredient<CosmiliteBar>()
                .AddIngredient<GalacticaSingularity>()
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }
}
