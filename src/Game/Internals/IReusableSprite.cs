namespace SpaceShooter.Game;


public interface IReusableSprite
{
    bool IsActive { get; set; }

    Guid Uid { get; }

    void ResetAnimationState();

    Task AnimateDisappearing();
}