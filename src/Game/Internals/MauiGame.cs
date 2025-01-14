namespace SpaceShooter.Game;

public class MauiGame : SkiaLayout
{

    private ActionOnTickAnimator _appLoop;
    protected long LastFrameTimeNanos;

    public MauiGame()
    {
        KeyboardManager.KeyDown += OnKeyboardDownEvent;
        KeyboardManager.KeyUp += OnKeyboardUpEvent;
    }

    ~MauiGame()
    {
        KeyboardManager.KeyUp -= OnKeyboardUpEvent;
        KeyboardManager.KeyDown -= OnKeyboardDownEvent;
    }

    protected virtual void OnResumed()
    {
    }

    protected virtual void OnPaused()
    {
    }

   
    /// <param name="deltaMs"></param>
    public virtual void GameLoop(float deltaMs)
    {

    }

  
    public virtual void StopLoop()
    {
        _appLoop.Stop();
    }

   
    /// <param name="delayMs"></param>
    public void StartLoop(int delayMs = 0)
    {
        if (_appLoop == null)
        {
            _appLoop = new(this, GameTick);
        }
        _appLoop.Start(delayMs);
    }

  
    /// <param name="frameTime"></param>
    protected virtual void GameTick(long frameTime)
    {
      
        float deltaTime = (frameTime - LastFrameTimeNanos) / 1_000_000_000.0f;
        LastFrameTimeNanos = frameTime;

        GameLoop(deltaTime);
    }

    private bool _IsPaused;
    public bool IsPaused
    {
        get
        {
            return _IsPaused;
        }
        set
        {
            if (_IsPaused != value)
            {
                _IsPaused = value;
                OnPropertyChanged();
            }
        }
    }

    public void Pause()
    {
        IsPaused = true;
        OnPaused();
    }

    public void Resume()
    {
        LastFrameTimeNanos = SkiaControl.GetNanoseconds();
        IsPaused = false;
        OnResumed();
    }

    #region KEYS

  
    /// <param name="key"></param>
    public virtual void OnKeyDown(MauiKey key)
    {

    }

    
    /// <param name="key"></param>
    public virtual void OnKeyUp(MauiKey key)
    {

    }


 
    /// <param name="sender"></param>
    /// <param name="key"></param>
    public void OnKeyboardDownEvent(object sender, MauiKey key)
    {
        OnKeyDown(key);
    }

    
    /// <param name="sender"></param>
    /// <param name="key"></param>
    public void OnKeyboardUpEvent(object sender, MauiKey key)
    {
        OnKeyUp(key);
    }


    #endregion

}