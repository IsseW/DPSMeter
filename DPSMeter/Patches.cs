using HarmonyLib;
using TMPro;
using UnityEngine;

namespace DPSMeter
{
    [HarmonyPatch(typeof(ClientSend))]
    public class ClientSendPatch
    {
        [HarmonyPatch(nameof(ClientSend.PlayerDamageMob)), HarmonyPrefix]
        public static void Mob(ClientSend __instance, int damage)
        {
            if (DPSMeter.instance)
                DPSMeter.instance.AddDamage(damage);
        }

        [HarmonyPatch(nameof(ClientSend.PlayerHitObject)), HarmonyPrefix]
        public static void Object(ClientSend __instance, int damage)
        {
            if (DPSMeter.instance)
                DPSMeter.instance.AddDamage(damage);
        }
    }

    [HarmonyPatch(typeof(StatusUI))]
    public class StatusUIPatch
    {

        [HarmonyPatch(nameof(StatusUI.Start)), HarmonyPostfix]
        public static void Start(StatusUI __instance)
        {
            var copy = Object.Instantiate(__instance.hpText.gameObject, __instance.hpText.transform.parent);
            copy.gameObject.name = "DPSMeter";
            copy.transform.position += new Vector3(30, 60);
            copy.AddComponent<DPSMeter>();
        }
    }
}
