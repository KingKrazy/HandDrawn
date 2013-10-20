//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//-----------------------------------------------------------------------------

//------------------------------------------------------------------------------
//
// Audio
//
//------------------------------------------------------------------------------
datablock AudioProfile( LevelSaved )
{
    filename    = "./data/audio/general/LevelSaved.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonSpawnSound0 )
{
    filename    = "./data/audio/dragon/startup 1a.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonSpawnSound1 )
{
    filename    = "./data/audio/dragon/startup 1b.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( TuftSound )
{
    filename    = "./data/audio/dragon/fs_grass.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonRunSound0 )
{
    filename    = "./data/audio/dragon/grass_step1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonRunSound1 )
{
    filename    = "./data/audio/dragon/grass_step2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonRunSound2 )
{
    filename    = "./data/audio/dragon/grass_step3.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonSlideSound )
{
    filename    = "./data/audio/dragon/slide.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonJumpSound )
{
    filename     = "./data/audio/dragon/jump.wav";
    description = "SoundOnce";
    jump        = 0.5;
    preload     = true;
};

datablock AudioProfile( DragonLandSound )
{
    filename    = "./data/audio/dragon/land.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonDamageSound )
{
    filename    = "./data/audio/dragon/ouch.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonDieSound0 )
{
    filename    = "./data/audio/dragon/die 1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonDieSound1 )
{
    filename    = "./data/audio/dragon/die 2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( DragonClimbUpSound )
{
    filename    = "./data/audio/dragon/rope_climb.wav";
    description = "SoundLoop";
    preload     = true;
};

datablock AudioProfile( DragonClimbDownSound )
{
    filename    = "./data/audio/dragon/rope_slide.wav";
    description = "SoundLoop";
    preload     = true;
};

datablock AudioProfile( FireballImpactSound )
{
    filename    = "./data/audio/weapons/FireballImpact.wav";
    description = "SoundOnce";
    preload     = true;
};

//------------------------------------------------------------------------------
//
// Graphics
//
//------------------------------------------------------------------------------

new t2dImageMapDatablock( DragonBlinkImagemap )
{
    imageName = "./data/images/Dragon/blink.png";
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

new t2dAnimationDatablock( DragonActionAnimation )
{
    imageMap = "DragonBlinkImagemap";
    animationFrames = "0";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonClimbImageMap )
{
    imageName = "./data/images/Dragon/Climb.png";
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
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonClimbupAnimation )
{
    imageMap = "DragonClimbImageMap";
    animationFrames = "0 1 2 3 4";
    animationTime = "0.2";
    animationPingPong = "1";
    randomStart = "0";
    stepFrames  = "0 4";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonClimb_to_ClimbIdleImageMap )
{
    imageName = "./data/images/Dragon/Climb_to_ClimbIdle.png";
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
    cellCountY = "1";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonClimbDown_to_ClimbIdleAnimation )
{
    imageMap = "DragonClimb_to_ClimbIdleImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonClimbUp_to_ClimbIdleAnimation )
{
    imageMap = "DragonClimb_to_ClimbIdleImageMap";
    animationFrames = "2";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonClimbIdleImageMap )
{
    imageName = "./data/images/Dragon/ClimbIdle.png";
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
    cellCountX = "1";
    cellCountY = "1";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonClimbIdleAnimation )
{
    imageMap = "DragonClimbIdleImageMap";
    animationFrames = "0";
    animationTime = "0.3";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonFallImageMap )
{
    imageName = "./data/images/Dragon/Fall.png";
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
    cellCountX = "2";
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonFallAnimation )
{
    imageMap = "DragonFallImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.15";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonFlyImageMap )
{
    imageName = "./data/images/Dragon/fly.png";
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

new t2dAnimationDatablock( DragonGlideAnimation )
{
    imageMap = "DragonFlyImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.2";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};
new t2dImageMapDatablock( DragonDieImageMap )
{
    imageName = "./data/images/Dragon/die.png";
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
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( DragonIdleImageMap )
{
    imageName = "./data/images/Dragon/Idle.png";
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
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonIdleAnimation )
{
    imageMap = "DragonIdleImageMap";
    animationFrames = "0 2 3 4 5";
    animationTime = "0.4";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonJumpImageMap )
{
    imageName = "./data/images/Dragon/Jump.png";
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
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonJumpAnimation )
{
    imageMap = "DragonJumpImageMap";
    animationFrames = "0 1 2 3 4 5";
    animationTime = "0.05";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonJump_to_FallImageMap )
{
    imageName = "./data/images/Dragon/Jump_to_Fall.png";
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
    cellCountX = "2";
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonJump_to_FallAnimation )
{
    imageMap = "DragonJump_to_FallImageMap";
    animationFrames = "0 1 2 3 4";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonRun_to_FallAnimation )
{
    imageMap = "DragonJump_to_FallImageMap";
    animationFrames = "1 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonCrouchImageMap )
{
    imageName = "./data/images/Dragon/crouch.png";
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

new t2dAnimationDatablock( DragonCrouchAnimation )
{
    imageMap = "DragonCrouchImageMap";
    animationFrames = "0 1 2 3 5 6";
    animationTime = "0.2";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonFall_to_LandAnimation )
{
    imageMap = "DragonJump_to_FallImageMap";
    animationFrames = "2 1";
    animationTime = "0.166667";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonrunJump_to_RunFallAnimation )
{
    imageMap = "DragonJump_to_FallImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonClimbJump_to_FallAnimation )
{
    imageMap = "DragonJump_to_FallImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonClimbJump_to_RunFallAnimation )
{
    imageMap = "DragonJump_to_FallImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonLandImageMap )
{
    imageName = "./data/images/Dragon/land.png";
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
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonFall_to_RunAnimation )
{
    imageMap = "DragonLandImageMap";
    animationFrames = "0";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonFall_to_IdleAnimation )
{
    imageMap = "DragonLandImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.1";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DragonLandAnimation )
{
    imageMap = "DragonLandImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.1";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonRunImageMap )
{
    imageName = "./data/images/Dragon/Run/Run.png";
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
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( DragonRun_to_SlideImageMap )
{
    imageName = "./data/images/Dragon/Run_to_Slide.png";
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
    cellCountX = "2";
    cellCountY = "1";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonRun_to_SlideAnimation )
{
    imageMap = "DragonRun_to_SlideImageMap";
    animationFrames = "0";
    animationTime = "0.0333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonSlideImageMap )
{
    imageName = "./data/images/Dragon/Slide.png";
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
    cellCountX = "2";
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonSlideAnimation )
{
    imageMap = "DragonSlideImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.25";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonSlide_to_IdleImageMap )
{
    imageName = "./data/images/Dragon/Slide_to_Idle.png";
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
    cellCountX = "4";
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonSlide_to_IdleAnimation )
{
    imageMap = "DragonSlide_to_IdleImageMap";
    animationFrames = "0 1 2 3 4 5 6 7";
    animationTime = "0.4";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonClimbDownImageMap )
{
    imageName = "./data/images/Dragon/SlideDown.png";
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
    cellCountX = "2";
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonClimbDownAnimation )
{
    imageMap = "DragonClimbDownImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.15";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonSpawnImageMap )
{
    imageName = "./data/images/Dragon/Spawn.png";
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

new t2dAnimationDatablock( DragonSpawnAnimation )
{
    imageMap = "DragonSpawnImageMap";
    animationFrames = "0 1 2 3 4 5 6 7 8";
    animationTime = "0.25";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DragonDamageImageMap )
{
    imageName = "./data/images/Dragon/damage.png";
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
    cellCountY = "2";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DragonDamageAnimation )
{
    imageMap = "DragonDamageImageMap";
    animationFrames = "0 1 2 3 4 5";
    animationTime = "0.2";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( FireBallImageMap )
{
    imageName = "./data/images/Weapons/FireBall.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "1";
    cellWidth = "192";
    cellHeight = "192";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( BombImageMap )
{
    imageName = "./data/images/Weapons/Bomb.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "1";
    cellWidth = "100";
    cellHeight = "100";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( BombAnimation )
{
    imageMap = "BombImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( FireBallAnimation1 )
{
    imageMap = "FireBallImageMap";
    animationFrames = "0 1 2";
    animationTime = "0.25";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( FireBallImpactImageMap )
{
    imageName = "./data/images/Weapons/FireBallImpact.png";
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
    cellWidth = "196";
    cellHeight = "196";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( FireBallImpactAnimation )
{
    imageMap = "FireBallImpactImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};