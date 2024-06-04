using CalamityMod;
using CalamityMod.Items;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables.Ores;
using CalamityMod.Rarities;
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
    public class CloakingInsignia : ModItem
    {
        public static readonly int MoveSpeedBonus = 15;
        public static readonly int RogueDamageBonus = 12;
        public static readonly int RogueVelocityBonus = 15;
        public static readonly int StealthMaxBonus = 5;
        public static readonly int AggroModifier = -600;

        public static readonly int CloakingBuffDurationInSec = 4;
        public static readonly int CloakingCooldownInSec = 40;

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 52;
            Item.accessory = true;
            Item.rare = ModContent.RarityType<PureGreen>();
            Item.value = CalamityGlobalItem.RarityPureGreenBuyPrice;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += MoveSpeedBonus / 100f;
            player.GetDamage<RogueDamageClass>() += RogueDamageBonus / 100f;
            player.Calamity().rogueVelocity += RogueVelocityBonus / 100f;
            player.Calamity().rogueStealthMax += StealthMaxBonus / 100f;
            player.aggro += AggroModifier;
            player.GetModPlayer<AccessoryPlayer>().cloakingInsignia = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BlunderBooster>()
                .AddIngredient<EtherealExtorter>()
                .AddIngredient<ExodiumCluster>(20)
                .AddIngredient<RuinousSoul>(5)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
