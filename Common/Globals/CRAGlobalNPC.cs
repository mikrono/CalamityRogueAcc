using CalamityMod.NPCs.AcidRain;
using CalamityMod.NPCs.TownNPCs;
using CalamityRogueAcc.Content.Items.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ID;
using CalamityMod.NPCs.Cryogen;

namespace CalamityRogueAcc.Common.Globals
{
    public class CRAGlobalNPC : GlobalNPC
    {
        internal static Dictionary<int, IItemDropRule> loots;

        public override void SetStaticDefaults()
        {
            loots = new()
            {
                { ModContent.NPCType<CragmawMire>(), new CommonDrop(ModContent.ItemType<Lead_Core>(), 10) },
                { ModContent.NPCType<Cryogen>(), new CommonDrop(ModContent.ItemType<Icy_Heart>(), 3) },
            };
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (loots.TryGetValue(npc.type, out IItemDropRule loot))
                npcLoot.Add(loot);
        }

        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == ModContent.NPCType<THIEF>())
            {
                shop.Add<Dagger_Charm>(Condition.Hardmode);
            }
            else if (shop.NpcType == NPCID.Steampunker)
            {
                shop.Add<Sonic_Arm>(Condition.DownedPlantera);
            }
        }
    }
}
