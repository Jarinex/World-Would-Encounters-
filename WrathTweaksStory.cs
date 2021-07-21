
using dnlib.DotNet;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Visual;
using Kingmaker.Visual.Sound;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.AI.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using HarmonyLib;
using Kingmaker.View;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WrathTweakMod
{


    class WrathStoryTweaks
    {
  


        static Consideration NoBuffBlur = ResourcesLibrary.TryGetBlueprint<BuffConsideration>("8a629688cbc97c142a5e7a41794c12c4");
       




        static class Spells
        {
            public static BlueprintAbility cape_of_wasps = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("e418c20c8ce362943a8025d82c865c1c");
           
            
     


        }



        static class AiActions
        {

            static public BlueprintAiCastSpell MakePreCast(BlueprintAiCastSpell from)
            {
                BlueprintAiCastSpell action = new BlueprintAiCastSpell();
                action.name = from.name.Replace("SLE_", "SLE_PRECAST_");
                return action;
            }
            

            static public BlueprintAiCastSpell cape_of_wasps_cast_first = createCastSpellAction("CastCapeOfWaspsBuff", Spells.cape_of_wasps,
                                                                                     new Consideration[] { },
                                                                                     new Consideration[] { },
                                                                                     base_score: 20.0f, combat_count: 1);


            

        }





        static BlueprintAiCastSpell createCastSpellAction(string name, BlueprintAbility spell, Consideration[] actor_consideration, Consideration[] target_consideration,
                                              float base_score = 1f, BlueprintAbility variant = null, int combat_count = 0, int cooldown_rounds = 0, int start_cooldown_rounds = 0, string guid = "", bool pre_cast = false)
        {
            BlueprintAiCastSpell action = new BlueprintAiCastSpell();
            action.m_Ability = spell.ToReference<BlueprintAbilityReference>();
            action.m_Variant = variant.ToReference<BlueprintAbilityReference>();
            action.m_ActorConsiderations = actor_consideration.Select(a => a.ToReference<ConsiderationReference>()).ToArray();
            action.m_TargetConsiderations = target_consideration.Select(a => a.ToReference<ConsiderationReference>()).ToArray();
            // if (pre_cast)
            //  action.name = "SLE_PRECAST_" + name;
            // else
            //   action.name = "SLE_" + name;
            action.BaseScore = base_score;
            action.CombatCount = combat_count;
            action.CooldownRounds = cooldown_rounds;
            action.StartCooldownRounds = start_cooldown_rounds;



            return action;
        }

 

      


        static internal void load()
        {

            //Test

            updateGiantFly();
           

        }


        //Test


        
        static void updateGiantFly()
        {

            var GiantFly = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("7e63418db0c4ec0428ab59c0947d628d");
            var displacement = ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("00402bae4442a854081264e498e7a833");
            var capeofwasps = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("e418c20c8ce362943a8025d82c865c1c");

            GiantFly.m_AddFacts = GiantFly.m_AddFacts.AddToArray(displacement.ToReference<BlueprintUnitFactReference>());
            GiantFly.m_AddFacts = GiantFly.m_AddFacts.AddToArray(capeofwasps.ToReference<BlueprintUnitFactReference>());



            GiantFly.Intelligence = 90;

            GiantFly.MaxHP = 9000;


            var brain = ResourcesLibrary.TryGetBlueprint<BlueprintBrain>("f5a012b8d0dab4f45924dcb2609df7b0");
            var test = ResourcesLibrary.TryGetBlueprint<BlueprintAiCastSpell>("a7f53648140a4e05991d4727bb0185ea");
            brain.m_Actions = brain.m_Actions.AddToArray(test.ToReference<BlueprintAiActionReference>());

        }

       


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
