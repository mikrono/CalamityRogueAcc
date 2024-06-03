using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Buffs.StatDebuffs;
using static Terraria.ModLoader.ModContent;

namespace CalamityRogueAcc.Common.ModPlayers
{
    public class AccessoryPlayer : ModPlayer
    {
        public int StealthStrikeArmorPen = 0;
        public bool leadCore = false;
        public bool Corrupted_Fang = false;
        public bool Dagger_Charm = false;

        public override void ResetEffects()
        {
            StealthStrikeArmorPen = 0;
            leadCore = false;
            Corrupted_Fang = false;
            Dagger_Charm = false;
        }

        public void NPCDebuffs(NPC target, bool melee, bool ranged, bool magic, bool summon, bool rogue, bool whip, bool proj = false, bool noFlask = false)
        {
            if (leadCore)
            {
                CalamityUtils.Inflict246DebuffsNPC(target, BuffType<Irradiated>());
            }
        }

    }
}
