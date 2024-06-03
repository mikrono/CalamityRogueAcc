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
    public class SharktoothShackle : ModItem
    {
        public static readonly int DefenseStat = 2;
        public static readonly int ArmorPenBonus = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DefenseStat, ArmorPenBonus);

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 1, 50);
            Item.defense = DefenseStat;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetArmorPenetration<GenericDamageClass>() += ArmorPenBonus;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SharkToothNecklace)
                .AddIngredient(ItemID.Shackle)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
