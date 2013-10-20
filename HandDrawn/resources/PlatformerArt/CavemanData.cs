//-----------------------------------------------------------------------------
//  Platformer Starter Kit
//  Copyright (C) Phillip O'Shea
//-----------------------------------------------------------------------------

//------------------------------------------------------------------------------
//
// Audio
//
//------------------------------------------------------------------------------

datablock AudioProfile( CavemanSpawnSound0 )
{
    filename    = "./data/audio/caveman/startup 1a.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanSpawnSound1 )
{
    filename    = "./data/audio/caveman/startup 1b.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanRunSound0 )
{
    filename    = "./data/audio/dragon/grass_step1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanRunSound1 )
{
    filename    = "./data/audio/dragon/grass_step2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanRunSound2 )
{
    filename    = "./data/audio/dragon/grass_step3.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanSlideSound )
{
    filename    = "./data/audio/dragon/slide.wav";
    description = "SoundLoop";
    preload     = true;
};

datablock AudioProfile( CavemanJumpSound )
{
    filename     = "./data/audio/dragon/jump.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanLandSound )
{
    filename    = "./data/audio/dragon/land.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanDamageSound )
{
    filename    = "./data/audio/caveman/ouch.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanDieSound0 )
{
    filename    = "./data/audio/caveman/die 1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanDieSound1 )
{
    filename    = "./data/audio/caveman/die 2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanClimbUpSound )
{
    filename    = "./data/audio/dragon/rope_climb.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CavemanClimbDownSound )
{
    filename    = "./data/audio/dragon/rope_slide.wav";
    description = "SoundLoop";
    preload     = true;
};

datablock AudioProfile( BoneImpactSound )
{
    filename    = "./data/audio/weapons/BoneImpact.wav";
    description = "SoundOnce";
    preload     = true;
};

//------------------------------------------------------------------------------
//
// Graphics
//
//------------------------------------------------------------------------------

new t2dImageMapDatablock( CavemanBlinkImagemap )
{
    imageName = "./data/images/Caveman/blink.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "0";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "-1";
    cellCountY = "-1";
    cellWidth = "170";
    cellHeight = "170";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanActionAnimation )
{
    imageMap = "CavemanBlinkImagemap";
    animationFrames = "0";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanClimbImageMap )
{
    imageName = "./data/images/Caveman/Climb.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanClimbupAnimation )
{
    imageMap = "CavemanClimbImageMap";
    animationFrames = "0 1 2 3 4";
    animationTime = "0.2";
    animationPingPong = "1";
    randomStart = "0";
    startFrame = "0";
    stepFrames = "5 11";
};

new t2dImageMapDatablock( CavemanClimb_to_ClimbIdleImageMap )
{
    imageName = "./data/images/Caveman/Climb_to_ClimbIdle.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanClimbDown_to_ClimbIdleAnimation )
{
    imageMap = "CavemanClimb_to_ClimbIdleImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanClimbUp_to_ClimbIdleAnimation )
{
    imageMap = "CavemanClimb_to_ClimbIdleImageMap";
    animationFrames = "2";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanClimbIdleImageMap )
{
    imageName = "./data/images/Caveman/ClimbIdle.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanClimbIdleAnimation )
{
    imageMap = "CavemanClimbIdleImageMap";
    animationFrames = "0 1 2 3 4 5";
    animationTime = "0.3";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanFallImageMap )
{
    imageName = "./data/images/Caveman/Fall.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanFallAnimation )
{
    imageMap = "CavemanFallImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.15";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanFlyImageMap )
{
    imageName = "./data/images/Caveman/fly.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanGlideAnimation )
{
    imageMap = "CavemanFlyImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.2";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanDieImageMap )
{
    imageName = "./data/images/Caveman/die.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanDieAnimation )
{
    imageMap = "CavemanDieImageMap";
    animationFrames = "0 1 2 3 4 5 6 7";
    animationTime = "0.416667";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanIdleImageMap )
{
    imageName = "./data/images/Caveman/Idle.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanIdleAnimation )
{
    imageMap = "CavemanIdleImageMap";
    animationFrames = "0 1 2 3 4 5";
    animationTime = "0.4";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanJumpImageMap )
{
    imageName = "./data/images/Caveman/Jump.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanJumpAnimation )
{
    imageMap = "CavemanJumpImageMap";
    animationFrames = "1 2 3 4 5";
    animationTime = "0.05";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanJump_to_FallImageMap )
{
    imageName = "./data/images/Caveman/Jump_to_Fall.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanJump_to_FallAnimation )
{
    imageMap = "CavemanJump_to_FallImageMap";
    animationFrames = "0 1 2 3 4";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanRun_to_FallAnimation )
{
    imageMap = "CavemanJump_to_FallImageMap";
    animationFrames = "1 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanFall_to_LandAnimation )
{
    imageMap = "CavemanJump_to_FallImageMap";
    animationFrames = "2 1";
    animationTime = "0.166667";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanrunJump_to_RunFallAnimation )
{
    imageMap = "CavemanJump_to_FallImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanClimbJump_to_FallAnimation )
{
    imageMap = "CavemanJump_to_FallImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanClimbJump_to_RunFallAnimation )
{
    imageMap = "CavemanJump_to_FallImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanLandImageMap )
{
    imageName = "./data/images/Caveman/land.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( CavemanCrouchImageMap )
{
    imageName = "./data/images/Caveman/crouch.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanCrouchAnimation )
{
    imageMap = "CavemanCrouchImageMap";
    animationFrames = "0 1 2 3 4 5 6";
    animationTime = "0.2";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanFall_to_RunAnimation )
{
    imageMap = "CavemanLandImageMap";
    animationFrames = "0";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanFall_to_IdleAnimation )
{
    imageMap = "CavemanLandImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.15";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( CavemanLandAnimation )
{
    imageMap = "CavemanLandImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.375";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanRunImageMap )
{
    imageName = "./data/images/Caveman/run.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanRunAnimation )
{
    imageMap = "CavemanRunImageMap";
    animationFrames = "0 1 2 3 4 5";
    animationTime = "0.3";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
    stepFrames = "5 11";
};

new t2dImageMapDatablock( CavemanRun_to_SlideImageMap )
{
    imageName = "./data/images/Caveman/Run_to_Slide.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanRun_to_SlideAnimation )
{
    imageMap = "CavemanRun_to_SlideImageMap";
    animationFrames = "0";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanSlideImageMap )
{
    imageName = "./data/images/Caveman/Slide.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanSlideAnimation )
{
    imageMap = "CavemanSlideImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.25";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanSlide_to_IdleImageMap )
{
    imageName = "./data/images/Caveman/Slide_to_Idle.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanSlide_to_IdleAnimation )
{
    imageMap = "CavemanSlide_to_IdleImageMap";
    animationFrames = "0 1 2 3 4 5 6 7";
    animationTime = "0.4";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanClimbDownImageMap )
{
    imageName = "./data/images/Caveman/SlideDown.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanClimbDownAnimation )
{
    imageMap = "CavemanClimbDownImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.15";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanSpawnImageMap )
{
    imageName = "./data/images/Caveman/Spawn.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanSpawnAnimation )
{
    imageMap = "CavemanSpawnImageMap";
    animationFrames = "0 1 2 3 4 5 6 7 8";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( CavemanDamageImageMap )
{
    imageName = "./data/images/Caveman/damage.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "332";
    cellHeight = "332";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( CavemanDamageAnimation )
{
    imageMap = "CavemanDamageImageMap";
    animationFrames = "0 1 2 3 4 5";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( BoneImageMap )
{
    imageName = "./data/images/Weapons/Bone.png";
    imageMode = "FULL";
    frameCount = "-1";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "-1";
    cellCountY = "-1";
    cellWidth = "0";
    cellHeight = "0";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( BoneImpactImageMap )
{
    imageName = "./data/images/Weapons/BoneImpact.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "-1";
    cellCountY = "-1";
    cellWidth = "48";
    cellHeight = "48";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( BoneFragmentImageMap )
{
    imageName = "./data/images/Weapons/BoneFragment.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "-1";
    cellCountY = "-1";
    cellWidth = "504";
    cellHeight = "481";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( BoneFragmentAnimation )
{
    imageMap = "BoneFragmentImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};