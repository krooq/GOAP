﻿using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Demos.Complex.Behaviours;
using CrashKonijn.Goap.Demos.Complex.Interfaces;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace CrashKonijn.Goap.Demos.Complex.Sensors.Target
{
    public class ClosestSourceSensor<T> : LocalTargetSensorBase
        where T : IGatherable
    {
        private ItemSourceBase<T>[] collection;
        
        public override void Created()
        {
            this.collection = Compatibility.FindObjectsOfType<ItemSourceBase<T>>();
        }

        public override void Update()
        {
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references)
        {
            var closest = this.collection.Closest(agent.Transform.position);
            
            if (closest == null)
                return null;
            
            return new TransformTarget(closest.transform);
        }
    }
}