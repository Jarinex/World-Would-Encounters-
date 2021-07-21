using UnityModManagerNet;
using System;
using System.Reflection;
using System.Linq;
using Kingmaker.Blueprints;
using System.Collections.Generic;
using Kingmaker.PubSubSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Controllers;
using HarmonyLib;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints.JsonSystem;

namespace WrathTweakMod
{

    internal class Main
    {

        internal static UnityModManagerNet.UnityModManager.ModEntry.ModLogger logger;
        internal static HarmonyLib.Harmony harmony;
 

        static readonly Dictionary<Type, bool> typesPatched = new Dictionary<Type, bool>();
        static readonly List<String> failedPatches = new List<String>();
        static readonly List<String> failedLoading = new List<String>();

        [System.Diagnostics.Conditional("DEBUG")]
        internal static void DebugLog(string msg)
        {
            if (logger != null) logger.Log(msg);
        }
        internal static void DebugError(Exception ex)
        {
            if (logger != null) logger.Log(ex.ToString() + "\n" + ex.StackTrace);
        }
        internal static bool enabled;


        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                logger = modEntry.Logger;
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            

            }
            catch (Exception ex)
            {
                DebugError(ex);
                throw ex;
            }
            return true;
        }

        [HarmonyLib.HarmonyPatch(typeof(BlueprintsCache), "Init")]
        
        static class WrathTweaks

        {
            [HarmonyLib.HarmonyBefore(new string[] { "WrathTweakMod" })]

            static void Postfix()
            {
                
                try
                {
                    Main.logger.Log("Loading Wrath Tweak Mod");



                  //  WrathSpellsTweaks.load();
                    WrathStoryTweaks.load();

                }



                catch (Exception ex)
                {
                    Main.DebugError(ex);
                }
            }
        }

        internal static Exception Error(String message)
        {
            logger?.Log(message);
            return new InvalidOperationException(message);
        }
    }

    public static class GuidStorage
    {
        static Dictionary<string, string> guids_in_use = new Dictionary<string, string>();
        static bool allow_guid_generation;

        static public void load(string file_content)
        {
            load(file_content, false);
        }

        static public void load(string file_content, bool debug_mode)
        {
            allow_guid_generation = debug_mode;
            guids_in_use = new Dictionary<string, string>();
            using (System.IO.StringReader reader = new System.IO.StringReader(file_content))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] items = line.Split('\t');
                    guids_in_use.Add(items[0], items[1]);
                }
            }
        }

        static public void dump(string guid_file_name)
        {
            using (System.IO.StreamWriter sw = System.IO.File.CreateText(guid_file_name))
            {
                foreach (var pair in guids_in_use)
                {
                    
                    var existing = ResourcesLibrary.TryGetBlueprint<BlueprintScriptableObject>(pair.Value);
                    if (existing != null)
                    {
                        sw.WriteLine(pair.Key + '\t' + pair.Value + '\t' + existing.GetType().FullName);
                    }
                }
            }
        }

        static public void addEntry(string name, string guid)
        {
            string original_guid;
            if (guids_in_use.TryGetValue(name, out original_guid))
            {
                if (original_guid != guid)
                {
                    throw Main.Error($"Asset: {name}, is already registered for object with another guid: {guid}");
                }
            }
            else
            {
                guids_in_use.Add(name, guid);
            }
        }


        static public bool hasStoredGuid(string blueprint_name)
        {
            string stored_guid = "";
            return guids_in_use.TryGetValue(blueprint_name, out stored_guid);
        }


        static public string getGuid(string name)
        {
            string original_guid;
            if (guids_in_use.TryGetValue(name, out original_guid))
            {
                return original_guid;
            }
            else if (allow_guid_generation)
            {
                return Guid.NewGuid().ToString("N");
            }
            else
            {
                throw Main.Error($"Missing AssetId for: {name}"); //ensure that no guids generated in release mode
            }
        }


        static public string maybeGetGuid(string name, string new_guid = "")
        {
            string original_guid;
            if (guids_in_use.TryGetValue(name, out original_guid))
            {
                return original_guid;
            }
            else
            {
                return new_guid;
            }
        }

    }
}