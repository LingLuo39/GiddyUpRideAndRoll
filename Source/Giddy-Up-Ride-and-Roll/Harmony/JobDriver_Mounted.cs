﻿using GiddyUpCore.Jobs;
using GiddyUpCore.Storage;
using GiddyUpRideAndRoll.Jobs;
using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace GiddyUpRideAndRoll.Harmony
{
    [HarmonyPatch(typeof(JobDriver_Mounted), "shouldCancelJob")]
    class JobDriver_Mounted_ShouldCancelJob
    {
        //TODO: maybe xml this instead of hard coding. 
        static JobDef[] allowedJobs = {GU_RR_JobDefOf.RideToJob, JobDefOf.Arrest, JobDefOf.AttackMelee, JobDefOf.AttackStatic, JobDefOf.Capture, JobDefOf.DropEquipment, JobDefOf.EscortPrisonerToBed, JobDefOf.ExtinguishSelf, JobDefOf.Flee, JobDefOf.FleeAndCower, JobDefOf.Goto, JobDefOf.GotoSafeTemperature, JobDefOf.GotoWander, JobDefOf.HaulToCell, JobDefOf.HaulToContainer, JobDefOf.Hunt, JobDefOf.Ignite, JobDefOf.Insult, JobDefOf.Kidnap, JobDefOf.Open, JobDefOf.RemoveApparel, JobDefOf.Rescue, JobDefOf.TakeWoundedPrisonerToBed, JobDefOf.Tame, JobDefOf.TradeWithPawn, JobDefOf.UnloadInventory, JobDefOf.UseArtifact, JobDefOf.UseVerbOnThing, JobDefOf.Vomit, JobDefOf.Wait, JobDefOf.WaitCombat, JobDefOf.WaitMaintainPosture, JobDefOf.WaitSafeTemperature, JobDefOf.WaitWander, JobDefOf.Wear};
        static void Postfix(ExtendedPawnData riderData, JobDriver_Mounted __instance, ref bool __result)
        {
            if (__instance.pawn.Faction == Faction.OfPlayer && !allowedJobs.Contains(__instance.Rider.CurJob.def))
            {
                __result = true;
            }
        }
    }
}
