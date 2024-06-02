using CalamityMod.Items.Materials;
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
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 40;
            Item.accessory = true;
            Item.defense = 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetArmorPenetration<GenericDamageClass>() += 15;
            player.GetAttackSpeed<GenericDamageClass>() += 15 / 100f;
            if (Main.eclipse)
            {
                player.GetDamage<GenericDamageClass>() += 10 / 100f;
                player.statDefense += 10;
            }
            if (Main.dayTime)
            {
                player.GetDamage<GenericDamageClass>() += 5 / 100f;
            }
            else
            {
                player.statDefense += 10;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<DarksunFragment>()
                .AddIngredient<SharktoothShackle>()
                .AddIngredient<UelibloomBar>()
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }
}
