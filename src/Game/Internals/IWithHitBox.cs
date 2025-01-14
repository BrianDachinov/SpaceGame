using SkiaSharp;

namespace SpaceShooter.Game;

public interface IWithHitBox
{
  
    /// <param name="time"></param>
    void UpdateState(long time);


    SKRect HitBox { get; }
}