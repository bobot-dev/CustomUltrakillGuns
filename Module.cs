using UMM;
using UnityEngine;

namespace CustomUltrakillGuns
{
    [UKPlugin("really cool custom weapons", "1.0.0", "words!!", true, true)]
    public class Module : UKMod
    {
        public const string GUID = "bot.customguns";

        static AssetBundle assetBundle;


        public override void OnModLoaded()
        {
            assetBundle = AssetBundle.LoadFromMemory(Properties.Resources.modAssets);
            ULTRAKIT.Loader.WeaponLoader.LoadWeapons(assetBundle);
        }
    }
}
