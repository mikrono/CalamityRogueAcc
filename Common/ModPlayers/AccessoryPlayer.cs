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
using Terraria.GameInput;
using CalamityRogueAcc.Common.Systems;
using CalamityRogueAcc.Content.Buffs;
using CalamityRogueAcc.Content.Items.Accessories;
using CalamityRogueAcc.Content.Cooldowns;
using Terraria.ID;
using CalamityMod.Balancing;
using CalamityMod.Projectiles;

namespace CalamityRogueAcc.Common.ModPlayers
{
    public class AccessoryPlayer : ModPlayer
    {
        public int stealthStrikeArmorPen = 0;
        public bool leadCore = false;
        public bool corrupted_Fang = false;
        public bool dagger_Charm = false;
        public bool cloakingInsignia = false;
        public bool icy_Heart = false;
        public bool vampireboneGlove = false;

        public override void ResetEffects()
        {
            stealthStrikeArmorPen = 0;
            leadCore = false;
            corrupted_Fang = false;
            dagger_Charm = false;
            cloakingInsignia = false;
            icy_Heart = false;
            vampireboneGlove = false;
        }

        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (item.CountsAsClass<RogueDamageClass>() && Player.Calamity().StealthStrikeAvailable())
            {
                if (dagger_Charm)
                {
                    const int knifeCount = 5;
                    const int knifeDamage = 50;
                    Vector2 BaseVelocity = velocity;
                    BaseVelocity.Normalize();
                    BaseVelocity *= 15f;

                    for (int i = 0; i < knifeCount; i++)
                    {
                        Vector2 newVelocity = BaseVelocity.RotatedBy(MathHelper.ToRadians(3 * (i - 2)));
                        Projectile.NewProjectile(Entity.GetSource_Accessory((new Dagger_Charm()).Item), position, newVelocity, ModContent.ProjectileType<VeneratedKnife>(), knifeDamage, 0f, Player.whoAmI);
                    }
                }

                if (icy_Heart)
                {
                    Vector2 baseVelocity = velocity;
                    baseVelocity.Normalize();
                    int icySpearIndex = Projectile.NewProjectile(Entity.GetSource_Accessory((new Icy_Heart()).Item), position, baseVelocity * 15f, ProjectileID.NorthPoleSpear, (int)(item.damage * Icy_Heart.icySpearDamgeMultiplier), knockback, Player.whoAmI);
                    Main.projectile[icySpearIndex].aiStyle = ProjAIStyleID.Spear;
                    Main.projectile[icySpearIndex].penetrate = 1;
                }
            }
            return true;
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Player.GetModPlayer<AccessoryPlayer>().cloakingInsignia && KeybindSystem.CloakingInsigniaKeybind.JustPressed && !Player.HasCooldown(CloakingInsigniaCooldown.ID))
            {
                Player.AddBuff(BuffType<CloakingInsigniaBuff>(), CloakingInsignia.CloakingBuffDurationInSec * 60);
                Player.AddCooldown(CloakingInsigniaCooldown.ID, CloakingInsignia.CloakingCooldownInSec * 60);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!proj.CountsAsClass<ThrowingDamageClass>())
                return;
            if (icy_Heart)
            {
                target.AddBuff(BuffID.Frostburn2, Icy_Heart.DebuffDurationInSec * 60);
            }

            if (leadCore)
            {
                target.AddBuff(BuffType<Irradiated>(), Lead_Core.DebuffDurationInSec * 60);
                if (proj.Calamity().stealthStrike)
                {
                    Projectile.NewProjectile(proj.GetSource_FromThis(), proj.Center, Vector2.Zero, ProjectileType<SulphuricNukesplosion>(), Lead_Core.ExplosionDamage, 2f, Player.whoAmI);
                }
            }

            if (vampireboneGlove && proj.Calamity().stealthStrike && Player.lifeSteal > 0f && !Player.moonLeech && target.lifeMax > 5)
            {
                float LifeStealRange = 3000f;
                float LifeStealAccessoryCooldownMultiplier = 3f;

                CalamityGlobalProjectile.SpawnLifeStealProjectile(proj, Player, 10, ProjectileID.VampireHeal, LifeStealRange, LifeStealAccessoryCooldownMultiplier);
            }
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
