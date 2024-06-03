using CalamityMod;
using CalamityMod.Projectiles;
using CalamityRogueAcc.Common.ModPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalamityRogueAcc.Common.Globals
{
    public class GlobalProjectiles : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        bool EffectFlag = false;

        public override void AI(Projectile projectile)
        {
            if (EffectFlag)
                return;

            CalamityGlobalProjectile calamityGlobalProjectile = projectile.GetGlobalProjectile<CalamityGlobalProjectile>();
            if (projectile.CountsAsClass<RogueDamageClass>() && calamityGlobalProjectile.stealthStrike)
            {
                projectile.ArmorPenetration += Main.player[projectile.owner].GetModPlayer<AccessoryPlayer>().StealthStrikeArmorPen;
            }
            EffectFlag = true;
        }
    }
}
