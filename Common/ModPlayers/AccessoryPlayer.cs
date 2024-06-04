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
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CalamityMod.Projectiles.Rogue;

namespace CalamityRogueAcc.Common.ModPlayers
{
    public class AccessoryPlayer : ModPlayer
    {
        public int StealthStrikeArmorPen = 0;
        public bool leadCore = false;
        public bool Corrupted_Fang = false;
        public bool Dagger_Charm = false;
        public bool CloakingInsignia = false;

        public override void ResetEffects()
        {
            StealthStrikeArmorPen = 0;
            leadCore = false;
            Corrupted_Fang = false;
            Dagger_Charm = false;
            CloakingInsignia = false;
        }

        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (item.CountsAsClass<RogueDamageClass>())
            {
                if (Player.Calamity().StealthStrikeAvailable() && Dagger_Charm)
                {
                    const int knifeCount = 5;
                    const int knifeDamage = 50;
                    Vector2 BaseVelocity = new(15f * Player.direction, 0);

                    for (int i = 0; i < knifeCount; i++)
                    {
                        Vector2 newVelocity = BaseVelocity.RotatedBy(MathHelper.ToRadians(3 * (i - 2)));
                        Projectile.NewProjectile(source, Player.Center, newVelocity, ModContent.ProjectileType<VeneratedKnife>(), knifeDamage, 0f, Player.whoAmI);
                    }
                }
            }
            return true;
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
