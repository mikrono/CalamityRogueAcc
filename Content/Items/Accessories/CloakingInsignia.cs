using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables.Ores;
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
        public static readonly int SpeedBonus = 15;
        public static readonly int RogueDamageBonus = 12;
        public static readonly int RogueVelocityBonus = 15;
        public static readonly int StealthMaxBonus = 5;
        public static readonly int AggroNegBonus = -600;

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 52;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

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
