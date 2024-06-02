using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace CalamityRogueAcc.Common.ModPlayers
{
    public class AccessoryPlayer : ModPlayer
    {
        public int StealthStrikeArmorPen = 0;

        public override void ResetEffects()
        {
            StealthStrikeArmorPen = 0;
        }

    }
}
