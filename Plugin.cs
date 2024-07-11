using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlinkTeleportAll
{
    [BepInPlugin("com.PizzaMan730.BlinkTeleportAll", "BlinkTeleportAll", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("BlinkTeleportAll has loaded!");

            Harmony harmony = new Harmony("com.PizzaMan730.BlinkTeleportAll");


            MethodInfo original = AccessTools.Method(typeof(QuantumTunnel), "Init");
            MethodInfo patch = AccessTools.Method(typeof(myPatches), "Init_Patch");
            harmony.Patch(original, new HarmonyMethod(patch));
        }

        public class myPatches
        {
            
            public static bool Init_Patch(ref bool ___isPlayer)
            {
                ___isPlayer = true;
                return true;
            }
        }
    }
}

//dotnet build "C:\Users\ajarc\BoplMods\BlinkTeleportAll\BoplBattleTemplate.csproj"