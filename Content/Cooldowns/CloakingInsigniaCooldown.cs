using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalamityMod.Cooldowns;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace CalamityRogueAcc.Content.Cooldowns
{
    public class CloakingInsigniaCooldown : CooldownHandler
    {
        //TODO: Texture. DisplayName
        public static new string ID => "CloakingInsignia";
        public override bool ShouldDisplay => false;
        public override LocalizedText DisplayName => Language.GetText("Mods.CalamityRogueAcc.Contents.Cooldowns.CloakingInsigniaCooldown");
        public override string Texture => base.Texture;
        public override Color OutlineColor => base.OutlineColor;
        public override Color CooldownStartColor => base.CooldownStartColor;
        public override Color CooldownEndColor => base.CooldownEndColor;

    }
}
