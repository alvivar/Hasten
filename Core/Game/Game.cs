// Game shared data & core communication between important stuff.

// Andrés Villalobos | twitter.com/matnesis | andresalvivar@gmail.com
// 2015/10/19 04:29 PM

// To do
// Auto create itself
// Auto create managers

using UnityEngine;

public class Game : MonoBehaviour
{

    // Important default data.
    public static float defaultOrthographicSize = 0;

    // Tag.Player
    private static Transform _player;
    public static Transform player
    {
        get
        {
            if (_player == null)
            {
                GameObject go = GameObject.FindGameObjectWithTag(Tag.Player);
                if (go) _player = go.transform;
            }

            return _player;
        }
    }

    private static Camera2D _camera2d;
    public static Camera2D camera2D
    {
        get
        {
            if (_camera2d == null) _camera2d = GameObject.FindObjectOfType<Camera2D>();
            return _camera2d;
        }
    }

    private static Whitescreen _whitescreen;
    public static Whitescreen whitescreen
    {
        get
        {
            if (_whitescreen == null) _whitescreen = GameObject.FindObjectOfType<Whitescreen>();
            return _whitescreen;
        }
    }

    private static Sounds _sounds;
    public static Sounds sounds
    {
        get
        {
            if (_sounds == null) _sounds = GameObject.FindObjectOfType<Sounds>();
            return _sounds;
        }
    }

    private static Palette _palette;
    public static Palette palette
    {
        get
        {
            if (_palette == null) _palette = GameObject.FindObjectOfType<Palette>();
            return _palette;
        }
    }

    private static Statistics _statistics;
    public static Statistics statistics
    {
        get
        {
            if (_statistics == null) _statistics = GameObject.FindObjectOfType<Statistics>();
            return _statistics;
        }
    }

    private static Timeflux _timeflux;
    public static Timeflux timeflux
    {
        get
        {
            if (_timeflux == null) _timeflux = GameObject.FindObjectOfType<Timeflux>();
            return _timeflux;
        }
    }

    private static Canvas _canvas;
    public static Canvas canvas
    {
        get
        {
            if (_canvas == null) _canvas = GameObject.FindObjectOfType<Canvas>();
            return _canvas;
        }
    }

    // We need a particle manager!
    // private static Particles _particles;
    // public static Particles particles
    // {
    //     get
    //     {
    //         if (_particles == null) _particles = GameObject.FindObjectOfType<Particles>();
    //         return _particles;
    //     }
    // }

    private static Camera2DOffsetCaster _offsetCaster;
    public static Camera2DOffsetCaster offsetCaster
    {
        get
        {
            if (_offsetCaster == null) _offsetCaster = GameObject.FindObjectOfType<Camera2DOffsetCaster>();
            return _offsetCaster;
        }
    }
}