datablock TriggerData(CheckpointTrigger)
{
   tickPeriodMS = 100;
};

datablock TriggerData(CheckpointTrigger)
{
   tickPeriodMS = 100;
};

function CheckpointTrigger::onEnterTrigger(%this,%trigger,%obj)
{
   //%this.getName
   %name = %trigger.getname();
   
   // Bad, should be a commandtoclient
   cp.setcurrent(%name);

   Parent::onEnterTrigger(%this,%trigger,%obj);
}

function CheckpointTrigger::onLeaveTrigger(%this,%trigger,%obj)
{
   Parent::onLeaveTrigger(%this,%trigger,%obj);
}

function CheckpointTrigger::onTickTrigger(%this,%trigger)
{
   Parent::onTickTrigger(%this,%trigger);
}

function CheckpointTrigger::onEnterTrigger(%this,%trigger,%obj)
{
   //%this.getName
   %name = %trigger.getname();
   
   // Bad, should be a commandtoclient
   cp.setcurrent(%name);

   Parent::onEnterTrigger(%this,%trigger,%obj);
}

function CheckpointTrigger::onLeaveTrigger(%this,%trigger,%obj)
{
   Parent::onLeaveTrigger(%this,%trigger,%obj);
}

function CheckpointTrigger::onTickTrigger(%this,%trigger)
{
   Parent::onTickTrigger(%this,%trigger);
}
///More…

new SimGroup(CheckPoints) {

      new SpawnSphere(1) {
         Position = "34.1473 -152.619 108.67";
         rotation = "0 0 1 130.062";
         scale = "0.940827 1.97505 1";
         dataBlock = "SpawnSphereMarker";
         Radius = "10";
         sphereWeight = "1";
         indoorWeight = "1";
         outdoorWeight = "1";
            locked = "False";
            homingCount = "0";
            lockCount = "0";
      };
      new SpawnSphere(2) {
         Position = "42.7715 -225.175 165.694";
         rotation = "0 0 1 130.062";
         scale = "0.940827 1.97505 1";
         dataBlock = "SpawnSphereMarker";
         Radius = "10";
         sphereWeight = "1";
         indoorWeight = "1";
         outdoorWeight = "1";
            locked = "False";
            homingCount = "0";
            lockCount = "0";
      };
   };
   new Trigger(1) {
      Position = "23.0141 -134.828 102.986";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "CheckpointTrigger";
      polyhedron = "0.0000000 0.0000000 0.0000000 1.0000000 0.0000000 0.0000000 0.0000000 -1.0000000 0.0000000 0.0000000 0.0000000 1.0000000";
   };
   new Trigger(2) {
      Position = "23.0141 -134.828 102.986";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "CheckpointTrigger";
      polyhedron = "0.0000000 0.0000000 0.0000000 1.0000000 0.0000000 0.0000000 0.0000000 -1.0000000 0.0000000 0.0000000 0.0000000 1.0000000";
   };