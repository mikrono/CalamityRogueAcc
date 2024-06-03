using CalamityMod;
using CalamityMod.Projectiles;
using CalamityRogueAcc.Common.ModPlayers;
using CalamityRogueAcc.Content.Items.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
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

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            AccessoryPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<AccessoryPlayer>();

            if (modPlayer.Corrupted_Fang && projectile.Calamity().stealthStrike)
            {
                target.AddBuff(BuffID.CursedInferno, Corrupted_Fang.CursedInfernoDebuffTime);
            }
        }
    }
}
