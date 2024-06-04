using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace CalamityRogueAcc.Common.Systems
{
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind CloakingInsigniaKeybind { get; private set; }

        public override void Load()
        {
            CloakingInsigniaKeybind = KeybindLoader.RegisterKeybind(Mod, "CloakingInsigniaKeybind", "P");
        }

        public override void Unload()
        {
            CloakingInsigniaKeybind = null;
        }
    }
}
