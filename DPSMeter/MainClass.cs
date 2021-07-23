using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DPSMeter
{


    [BepInPlugin(Guid, Name, Version)]
    public class MainClass : BaseUnityPlugin
    {
        public const string
            Name = "DPSMeter",
            Author = "Isse",
            Guid = Author + "." + Name,
            Version = "1.0.0.0";

        public static MainClass instance;
        public Harmony harmony;
        public ManualLogSource log;


        void Awake()
        {
            if (!instance)
                instance = this;
            else
                Destroy(this);

            log = Logger;
            harmony = new Harmony(Guid);
            harmony.PatchAll();

            log.LogMessage("DPSMETER ON!!!!");

        }
    }

}

