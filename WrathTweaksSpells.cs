
using dnlib.DotNet;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJson;

using UnityEngine.UI;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;




//namespace Kingmaker.UnitLogic.Mechanics.Actions
//{
   // public class CustomContextActionSpawnMonster : ContextAction
    //{

     //   public override string GetCaption()
       // {
       //     return "Summon monster";

      //  }

       // public override void RunAction()
      //  {
      //      UnitEntityData maybeCaster = base.Context.MaybeCaster;
      //      if (maybeCaster == null)
       //     {
       //         UberDebug.LogError(this, "Caster is missing", Array.Empty<object>());
           //     return;
           // }
        //    Vector3 vector = base.Target.Point;
        //    vector += new Vector3(3, 0, -2);
        //    vector = ObstacleAnalyzer.GetNearestNode(vector).clampedPosition;
        //    UnitEntityView unitEntityView = this.Blueprint.Prefab.Load(false);
        //    float radius = (unitEntityView != null) ? unitEntityView.Corpulence : 0.5f;
        //    FreePlaceSelector.PlaceSpawnPlaces(3, radius, vector);
        //    Game.Instance.EntityCreator.SpawnUnit(this.Blueprint, vector, Quaternion.identity, maybeCaster.HoldingState);
      //  }

      //  public BlueprintUnit Blueprint;
   // }

//}





//namespace WrathTweakMod
//{
   // class WrathSpellsTweaks
   // {

   //     static LibraryScriptableObject library = Main.library;
   //
   // //    static internal void load()
      //  {
     //       testsummongorum();
//
//
     //   }



        //static void testsummongorum()
      //  {
        //    var cleric_gorum = library.Get<BlueprintUnit>("4602809f9d59cc24a815d304715771c7");
        //
        //    var actions = Helpers.CreateRunActions(
        //       Helpers.Create<CustomContextActionSpawnMonster>(c => c.Blueprint = cleric_gorum),
        //       Helpers.Create<CustomContextActionSpawnMonster2>(c => c.Blueprint = cleric_gorum));

        //    var ability = Helpers.CreateAbility("Summon Spirits",
         //       "Summon Spirits",
         //      "Summon the spirits of recently slain clerics of gorum so that they may exact revenge on their enemy.",
          //      "",
          //      null,
         //       Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
          //      Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
           //     Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
           //     "",
           //     "",
            //    actions);

           // var summoncleric_resource = Helpers.CreateAbilityResource("summonclericResource", "", "", "", null);
           // summoncleric_resource.SetFixedResource(1);

      //  }






































        //public override string ToString()
      //  {
      //      return base.ToString();
     //   }

     //   public override bool Equals(object obj)
     //   {
       //     return base.Equals(obj);
      //  }

      //  public override int GetHashCode()
     //   {
      //      return base.GetHashCode();
     //   }
 //   }

//}